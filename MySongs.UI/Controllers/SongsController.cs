using Microsoft.AspNetCore.Mvc;
using MySongs.Services.Interfaces;
using MySongs.Common.DTOs;

namespace MySongs.UI.Controllers
{
    public class SongsController : Controller
    {
        private readonly ISongService _songService;

        public SongsController(ISongService songService)
        {
            _songService = songService;
        }

        public IActionResult Index()
        {
            var songs = _songService.GetAll();
            return View(songs);
        }

        public IActionResult Details(int id)
        {
            var song = _songService.GetById(id);
            return View(song);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SongDto song)
        {
            _songService.Add(song);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var song = _songService.GetById(id);
            return View(song);
        }

        [HttpPost]
        public IActionResult Edit(SongDto song)
        {
            _songService.Update(song);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _songService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}