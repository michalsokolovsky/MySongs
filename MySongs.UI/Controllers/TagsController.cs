using Microsoft.AspNetCore.Mvc;
using MySongs.Services.Interfaces;
using MySongs.Common.DTOs;

namespace MySongs.UI.Controllers
{
    public class TagsController : Controller
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        public IActionResult Index()
        {
            var tags = _tagService.GetAll();
            return View(tags);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TagDto tag)
        {
            _tagService.Add(tag);
            return RedirectToAction("Index");
        }
    }
}