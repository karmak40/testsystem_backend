using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testsystem.Models.Entities;

namespace testsystem.Interfaces.Repositories
{
    public interface IRatingRepository
    {

        ICollection<Rating> GetRatingsByAnswerId(int answerId);

        ICollection<Rating> GetRatingsByViewerId(int viewerId);

        Rating Get(int testId);

        int Add(Rating model);

        bool Remove(int id);

        bool Update(Rating model);

    }
}
