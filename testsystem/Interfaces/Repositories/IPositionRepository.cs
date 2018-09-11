using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testsystem.Models;
using testsystem.Models.Dto;

namespace testsystem.Interfaces.Repositories
{
    public interface IPositionRepository
    {
        ICollection<Position> GetPositions();

        bool AddPosition(Position model);

        ICollection<Position> RemovePosition(string id);
    }
}
