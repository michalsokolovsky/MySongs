using MySongs.Common.DTOs;
using MySongs.Services.Interfaces;

namespace MySongs.Api.Services
{
    public class RecommendationEngineService
    {
        private readonly IUserService _userService;
        private readonly ISongService _songService;
        private readonly ISongTagService _songTagService;
        private readonly IRecommendationService _recommendationService;

        public RecommendationEngineService(
            IUserService userService,
            ISongService songService,
            ISongTagService songTagService,
            IRecommendationService recommendationService)
        {
            _userService = userService;
            _songService = songService;
            _songTagService = songTagService;
            _recommendationService = recommendationService;
        }

        public async Task UpdateRecommendationsForAllUsers(int newSongId)
        {
            var users = _userService.GetAll();
            var newSongTags = _songTagService.GetTagsBySongId(newSongId);

            foreach (var user in users)
            {
                var isRelevant = await IsRelevantForUser(user.UserId, newSongTags);
                if (isRelevant)
                {
                    _recommendationService.Add(new RecommendationDto
                    {
                        UserId = user.UserId,
                        SongId = newSongId,
                        RecommendedAt = DateTime.Now
                    });
                }
            }
        }

        private async Task<bool> IsRelevantForUser(int userId, List<SongTagDto> newSongTags)
        {
            await Task.CompletedTask;

            if (!newSongTags.Any()) return true;

            // כאן אפשר להוסיף לוגיקה מתקדמת בעתיד
            // לעכשיו – כל שיר חדש מתאים לכל המשתמשים
            return true;
        }
    }
}