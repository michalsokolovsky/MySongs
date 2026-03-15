using MySongs.Common.DTOs;
using System.Collections.Generic;

namespace MySongs.Services.Interfaces
{
    public interface IRecommendationService
    {
        List<RecommendationDto> GetByUserId(int userId);
        void Add(RecommendationDto recommendation);
    }
}