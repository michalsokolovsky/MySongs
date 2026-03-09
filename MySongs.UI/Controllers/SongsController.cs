using Microsoft.AspNetCore.Mvc;
using MySongs.Repository;
using MySongs.Repository.Interfaces; // חיבור לממשק
using MySongs.Repository.Repositories; // חיבור למימוש

namespace MySongs.UI.Controllers
{
    public class SongsController : Controller
    {
        // יצירת משתנה שיחזיק את ה-Repository
        private readonly ISongRepository _songRepository;

        // "בנאי" (Constructor) - כאן ה-Controller מקבל את ה-Repository
        public SongsController()
        {
            // הערה: בהמשך נלמד איך המחשב מזריק את זה אוטומטית, 
            // כרגע ניצור מופע חדש ידנית כדי שתוכלי להריץ.
            _songRepository = new SongRepository();
        }

        public IActionResult Index()
        {
            // קריאה לפונקציה שיצרת ב-Repository!
            var songs = _songRepository.GetAll();

            // שליחת רשימת השירים לתצוגה (View)
            return View(songs);
        }
    }
}