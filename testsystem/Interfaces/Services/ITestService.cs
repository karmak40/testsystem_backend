using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testsystem.Models.Dto;

namespace testsystem.Interfaces.Services
{
    public interface ITestService
    {
        bool AddTest(TestDto dto);

        bool RemoveTest(int id);

        bool UpdateTest(TestDto dto);

        ICollection<TestDto> GetTests(int positionId);

    }
}
