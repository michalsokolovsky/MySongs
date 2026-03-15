using MySongs.Common.DTOs;
using MySongs.Repository.Interfaces;
using MySongs.Repository.Entities;
using MySongs.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MySongs.Services.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly IRecommendationRepository _repository;

        public RecommendationService(IRecommendationRepository repository)
        {
            _repository = repository;
        }

        public List<RecommendationDto> GetByUserId(int userId)
        {
            return _repository.GetByUserId(userId)
                .Select(r => new RecommendationDto
                {
                    RecommendationId = r.RecommendationId,
                    UserId = r.UserId,
                    SongId = r.SongId,
                    Score = r.Score,
                    IsSeen = r.IsSeen
                }).ToList();
        }

        public void Add(RecommendationDto recommendation)
        {
            _repository.Add(new Recommendation
            {
                UserId = recommendation.UserId,
                SongId = recommendation.SongId,
                Score = recommendation.Score,
                IsSeen = recommendation.IsSeen
            });
        }
    }
}