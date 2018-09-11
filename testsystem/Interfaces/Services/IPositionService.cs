using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testsystem.Models.Dto;

namespace testsystem.Interfaces.Services
{
    public interface IPositionService
    {
        void GetPosition();

        bool AddPosition(PositionDto dto);

    }
}
