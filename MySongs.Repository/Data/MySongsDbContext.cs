using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySongs.Repository.Entities;

namespace MySongs.Repository.Data
{
    public class MySongsDbContext : DbContext
    {
        // בנאי ראשון - בשביל ה-Migration
        public MySongsDbContext() { }

        // בנאי שני - בשביל ה-Program.cs
        public MySongsDbContext(DbContextOptions<MySongsDbContext> options) : base(options) { }

        public DbSet<Songs> Songs { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<SongTag> SongTags { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Recommendation> Recommendations { get; set; }
        public DbSet<ListeningHistory> ListeningHistorys { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // כאן את שמה את מחרוזת החיבור שלך ל-SQL המקומי
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MySongsDB;Trusted_Connection=True;");
            }
        }
    }
}