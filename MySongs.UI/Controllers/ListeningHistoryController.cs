using Microsoft.AspNetCore.Mvc;
using MySongs.Services.Interfaces;
using MySongs.Common.DTOs;

namespace MySongs.UI.Controllers
{
    public class ListeningHistoryController : Controller
    {
        private readonly IListeningHistoryService _historyService;

        public ListeningHistoryController(IListeningHistoryService historyService)
        {
            _historyService = historyService;
        }

        public IActionResult Index()
        {
            var history = _historyService.GetAll();
            return View(history);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ListeningHistoryDto history)
        {
            _historyService.Add(history);
            return RedirectToAction("Index");
        }
    }
}