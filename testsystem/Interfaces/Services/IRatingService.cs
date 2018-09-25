using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testsystem.Models.Dto;

namespace testsystem.Interfaces.Services
{
    public interface IRatingService
    {
        bool Add(RatingDto dto);

        bool AddRange(List<RatingDto> dtos);

        bool RemoveTest(int id);

        bool UpdateTest(RatingDto dto);

        RatingDto Get(int ratingId);

        ICollection<RatingDto> GetRatings(int answerId);
    }
}
