using MySongs.Common.DTOs;
using MySongs.Services.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace MySongs.Api.Services
{
    public class RecommendationEngineService
    {
        private readonly IUserService _userService;
        private readonly ISongService _songService;
        private readonly IRecommendationService _recommendationService;
        private readonly IListeningHistoryService _listeningHistoryService;
        private readonly string _apiKey;

        public RecommendationEngineService(
            IUserService userService,
            ISongService songService,
            IRecommendationService recommendationService,
            IListeningHistoryService listeningHistoryService,
            IConfiguration configuration)
        {
            _userService = userService;
            _songService = songService;
            _recommendationService = recommendationService;
            _listeningHistoryService = listeningHistoryService;
            _apiKey = configuration["OpenAI:ApiKey"]!;
        }

        public async Task UpdateRecommendationsForAllUsers(int newSongId)
        {
            var users = await _userService.GetAll();
            foreach (var user in users)
            {
                await GenerateRecommendationsForUser(user.UserId);
            }
        }

        public async Task GenerateRecommendationsForUser(int userId)
        {
            var oldRecs = await _recommendationService.GetByUserId(userId);
            foreach (var rec in oldRecs)
            {
                await _recommendationService.Delete(rec.RecommendationId);
            }

            var allSongs = await _songService.GetAll();
            var allHistory = await _listeningHistoryService.GetAll();
            var history = allHistory.Where(h => h.UserId == userId).ToList();

            if (!history.Any()) return;

            var listenedSongs = history
                .Select(h => allSongs.FirstOrDefault(s => s.SongId == h.SongId))
                .Where(s => s != null)
                .ToList();

            var notListened = allSongs
                .Where(s => !history.Any(h => h.SongId == s.SongId))
                .ToList();

            if (!notListened.Any()) return;

            var genreCount = listenedSongs
                .GroupBy(s => s!.Genre)
                .OrderByDescending(g => g.Count())
                .Select(g => $"{g.Key} ({g.Count()} האזנות)");

            var listenedText = string.Join(", ", listenedSongs.Select(s => $"{s!.Title} ({s.Genre})"));
            var genrePreference = string.Join(", ", genreCount);
            var candidatesText = string.Join("\n", notListened.Select(s => $"ID:{s.SongId} - {s.Title} ({s.Genre}) - {s.ArtistName}"));

            var prompt = $@"משתמש האזין לשירים הבאים: {listenedText}

                  העדפות ז'אנר לפי תדירות האזנה: {genrePreference}

                     מתוך הרשימה הבאה, בחר עד 3 שירים שהכי מתאימים לו - תן עדיפות לז'אנרים שהאזין אליהם הכי הרבה:
                  {candidatesText}
 
                   החזר JSON בלבד בפורמט: {{""songIds"": [1, 2, 3]}}";

            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);

                var requestBody = new
                {
                    model = "gpt-4o",
                    messages = new[]
                    {
                        new { role = "system", content = "You are a music recommendation expert. Return only valid JSON." },
                        new { role = "user", content = prompt }
                    },
                    response_format = new { type = "json_object" }
                };

                var content = new StringContent(
                    JsonConvert.SerializeObject(requestBody),
                    Encoding.UTF8,
                    "application/json");

                var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);
                var responseString = await response.Content.ReadAsStringAsync();

                dynamic jsonResponse = JsonConvert.DeserializeObject(responseString)!;
                string jsonContent = jsonResponse.choices[0].message.content;
                dynamic result = JsonConvert.DeserializeObject(jsonContent)!;

                var existingRecs = await _recommendationService.GetByUserId(userId);
                var existingIds = existingRecs.Select(r => r.SongId).ToList();

                foreach (var songId in result.songIds)
                {
                    int id = (int)songId;
                    if (!existingIds.Contains(id))
                    {
                        await _recommendationService.Add(new RecommendationDto
                        {
                            UserId = userId,
                            SongId = id,
                            RecommendedAt = DateTime.Now
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"שגיאה בהמלצות: {ex.Message}");
            }
        }
    }
}