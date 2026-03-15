using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySongs.Common.DTOs;
using MySongs.Services.Interfaces;

namespace MySongs.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListeningHistoryController : ControllerBase
    {
        private readonly IListeningHistoryService _listeningHistoryService;

        public ListeningHistoryController(IListeningHistoryService listeningHistoryService)
        {
            _listeningHistoryService = listeningHistoryService;
        }

        [HttpGet("user/{userId}")]
        [Authorize]
        public IActionResult GetByUser(int userId)
        {
            var history = _listeningHistoryService.GetAll()
                .Where(h => h.UserId == userId)
                .ToList();
            return Ok(history);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add([FromBody] ListeningHistoryDto history)
        {
            _listeningHistoryService.Add(history);
            return Ok("ההאזנה נרשמה");
        }
    }
}