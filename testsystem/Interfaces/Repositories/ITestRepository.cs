using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testsystem.Models.Entities;

namespace testsystem.Interfaces.Repositories
{
    public interface ITestRepository
    {
        ICollection<Test> GetTests(int positionId);

        bool AddTest(Test model);

        bool RemoveTest(int id);

        bool UpdateTest(Test model);
    }
}
