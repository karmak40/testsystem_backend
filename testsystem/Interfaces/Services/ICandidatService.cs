using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testsystem.Models.Dto;

namespace testsystem.Interfaces.Services
{
    public interface ICandidatService
    {
        bool AddCandidat(CandidatDto dto);
        bool UpdateCandidat(CandidatDto dto);
        IEnumerable<CandidatDto> GetCandidats(int positionId);

        CandidatDto GetCandidat(int id);

        bool DeleteCandidat(int Id);
    }
}
