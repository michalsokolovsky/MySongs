using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySongs.Common.DTOs;
using MySongs.Services.Interfaces;

namespace MySongs.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecommendationsController : ControllerBase
    {
        private readonly IRecommendationService _recommendationService;

        public RecommendationsController(IRecommendationService recommendationService)
        {
            _recommendationService = recommendationService;
        }

      
        [HttpGet("user/{userId}")]

        [Authorize]
        public IActionResult GetByUser(int userId)
        {
            var recommendations = _recommendationService.GetByUserId(userId);
            return Ok(recommendations);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add([FromBody] RecommendationDto recommendation)
        {
            _recommendationService.Add(recommendation);
            return Ok("ההמלצה נוספה");
        }
    }
}