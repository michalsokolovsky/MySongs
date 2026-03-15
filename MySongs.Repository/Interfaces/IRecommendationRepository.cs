using MySongs.Repository.Entities;
using System.Collections.Generic;

namespace MySongs.Repository.Interfaces
{
    public interface IRecommendationRepository
    {
        List<Recommendation> GetByUserId(int userId);
        void Add(Recommendation recommendation);
    }
}