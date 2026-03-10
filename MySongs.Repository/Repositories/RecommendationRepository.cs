using MySongs.Repository.Entities;
using MySongs.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MySongs.Repository.Repositories
{
    public class RecommendationRepository : IRecommendationRepository
    {
        private readonly IContext _context;

        public RecommendationRepository(IContext context)
        {
            _context = context;
        }

        public List<Recommendation> GetByUserId(int userId)
        {
            return _context.Recommendations
                .Where(r => r.UserId == userId)
                .ToList();
        }

        public void Add(Recommendation recommendation)
        {
            _context.Recommendations.Add(recommendation);
            _context.SaveChanges();
        }
    }
}