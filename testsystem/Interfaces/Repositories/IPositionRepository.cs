using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testsystem.Models;
using testsystem.Models.Dto;
using testsystem.Models.Entities;

namespace testsystem.Interfaces.Repositories
{
    public interface IPositionRepository
    {
        ICollection<Position> GetPositions();

        int AddPosition(Position model);

        ICollection<Position> RemovePosition(string id);

        Position GetPosition(int id);
    }
}
