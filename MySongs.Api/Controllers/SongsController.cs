using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySongs.Api.Services;
using MySongs.Common.DTOs;
using MySongs.Services.Interfaces;

namespace MySongs.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongsController : ControllerBase
    {
        private readonly ISongService _songService;
        private readonly ITagService _tagService;
        private readonly ISongTagService _songTagService;
        private readonly RecommendationEngineService _recommendationEngine;
        private readonly IConfiguration _configuration;

        public SongsController(
            ISongService songService,
            ITagService tagService,
            ISongTagService songTagService,
            RecommendationEngineService recommendationEngine,
            IConfiguration configuration)
        {
            _songService = songService;
            _tagService = tagService;
            _songTagService = songTagService;
            _recommendationEngine = recommendationEngine;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_songService.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var song = _songService.GetById(id);
            if (song == null) return NotFound();
            return Ok(song);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add([FromBody] SongDto song)
        {
            _songService.Add(song);
            return Ok("השיר נוסף");
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Update(int id, [FromBody] SongDto song)
        {
            song.SongId = id;
            _songService.Update(song);
            return Ok("השיר עודכן");
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            _songService.Delete(id);
            return Ok("השיר נמחק");
        }

        [HttpGet("{id}/tags")]
        public IActionResult GetSongTags(int id)
        {
            var songTags = _songTagService.GetTagsBySongId(id);
            var allTags = _tagService.GetAll();
            var tagNames = songTags
                .Select(st => allTags.FirstOrDefault(t => t.TagId == st.TagId)?.TagName)
                .Where(n => n != null)
                .ToList();
            return Ok(tagNames);
        }

        [HttpPost("upload")]
        [Authorize]
        public async Task<IActionResult> UploadSong(IFormFile audioFile, [FromForm] string artistName)
        {
            if (audioFile == null || audioFile.Length == 0)
                return BadRequest("לא הועלה קובץ");

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "audio");
            Directory.CreateDirectory(uploadsFolder);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(audioFile.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await audioFile.CopyToAsync(stream);
            }

            var audioUrl = $"{Request.Scheme}://{Request.Host}/audio/{fileName}";
            var apiKey = _configuration["OpenAI:ApiKey"]!;
            var aiService = new AIService(apiKey);
            var result = await aiService.AnalyzeSongMetadata(filePath);

            var song = new SongDto
            {
                Title = result.Title,
                ArtistName = artistName,
                Genre = result.Genre,
                LyricsSummary = result.Summary,
                AudioUrl = audioUrl,
                ReleaseDate = DateTime.Now
            };

            _songService.Add(song);

            var savedSong = _songService.GetAll()
                .OrderByDescending(s => s.SongId)
                .FirstOrDefault();

            if (savedSong != null)
            {
                _ = Task.Run(async () =>
                {
                    await _recommendationEngine.UpdateRecommendationsForAllUsers(savedSong.SongId);
                });
            }

            return Ok(savedSong);
        }
    }
}