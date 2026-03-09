using MySongs.Repository.Entities;
using MySongs.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySongs.Repository.Repositories
{
    public class SongRepository : ISongRepository
    {
        public void Add(Songs song)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Songs> GetAll()
        {
            return new List<Songs>
            {
             new Songs { SongId = 1, Title = "שיר בדיקה 1", ArtistName = "זמר א" },
              new Songs { SongId = 2, Title = "שיר בדיקה 2", ArtistName = "זמר ב" }
            };
        }

        public Songs GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Songs song)
        {
            throw new NotImplementedException();
        }
    }
}
