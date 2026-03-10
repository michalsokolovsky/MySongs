using Microsoft.AspNetCore.Mvc;
using MySongs.Services.Interfaces;
using MySongs.Common.DTOs;

namespace MySongs.UI.Controllers
{
    public class RecommendationsController : Controller
    {
        private readonly IRecommendationService _recommendationService;

        public RecommendationsController(IRecommendationService recommendationService)
        {
            _recommendationService = recommendationService;
        }

        public IActionResult Index(int userId)
        {
            var recommendations = _recommendationService.GetByUserId(userId);
            return View(recommendations);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RecommendationDto recommendation)
        {
            _recommendationService.Add(recommendation);
            return RedirectToAction("Index");
        }
    }
}