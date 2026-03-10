using Microsoft.AspNetCore.Mvc;
using MySongs.Services.Interfaces;
using MySongs.Common.DTOs;

namespace MySongs.UI.Controllers
{
    public class SongTagsController : Controller
    {
        private readonly ISongTagService _songTagService;

        public SongTagsController(ISongTagService songTagService)
        {
            _songTagService = songTagService;
        }

        public IActionResult Index(int songId)
        {
            var songTags = _songTagService.GetTagsBySongId(songId);
            return View(songTags);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SongTagDto songTag)
        {
            _songTagService.Add(songTag);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int songId, int tagId)
        {
            _songTagService.Delete(songId, tagId);
            return RedirectToAction("Index");
        }
    }
}