using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using testsystem.Models.Dto;
using testsystem.Models.Entities;

namespace testsystem.Interfaces.Repositories
{
    public interface IAnswerRepository
    {
        bool Add(Answer model);

        bool AddRange(List<Answer> models);

        Answer GetByRef(Guid reference);

        List<Answer> GetExisting(List<TestDto> tests, List<CandidatDto> candidats);

        Guid FindGuidByCandidat(int candidatId);

        Guid FindGuidByTest(int TestId);
    }
}
