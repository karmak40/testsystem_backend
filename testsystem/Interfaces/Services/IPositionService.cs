using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testsystem.Models.Dto;

namespace testsystem.Interfaces.Services
{
    public interface IPositionService
    {
        PositionDto GetPosition(int id);

        ICollection<PositionDto> GetPositions();

        bool AddPosition(PositionDto dto);

    }
}
