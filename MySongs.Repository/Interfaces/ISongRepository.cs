using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySongs.Repository.Entities; // מחבר את הממשק למודלים שלך

namespace MySongs.Repository.Interfaces
{
    public interface ISongRepository
    {

        List<Songs> GetAll();      // פונקציה שתחזיר את כל השירים
        Songs GetById(int id);     // פונקציה שתמצא שיר לפי מספר
        void Add(Songs song);      // פונקציה להוספת שיר חדש
        void Update(Songs song);   // פונקציה לעדכון שיר
        void Delete(int id);       // פונקציה למחיקת שיר

    }
}
