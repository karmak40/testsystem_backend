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

        /// <summary>
        /// Add Answer record after adding new test
        /// </summary>
        /// <param name="testId"></param>
        /// <param name="candidats"></param>
        /// <returns></returns>
        bool Add(int testId, List<CandidatDto> candidats);

        /// <summary>
        /// Add Answer record after adding new candidat
        /// </summary>
        /// <param name="candidatId"></param>
        /// <param name="tests"></param>
        /// <returns></returns>
        bool Add(int candidatId, List<TestDto> tests);

        AnswerDto GetByRef(Guid reference);
    }
}
