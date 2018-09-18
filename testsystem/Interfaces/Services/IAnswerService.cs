using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using testsystem.Models.Dto;

namespace testsystem.Interfaces.Services
{
    public interface IAnswerService
    {
        bool Add(int testId, List<CandidatDto> candidats);

        AnswerDto GetByRef(Guid reference);
    }
}
