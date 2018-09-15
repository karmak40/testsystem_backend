using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testsystem.Models.Entities;

namespace testsystem.Interfaces.Repositories
{
    public interface ICandidatRepositories
    {
        ICollection<Candidat> GetCandidats(int positionId);

        bool AddCandidat(Candidat model);

        bool RemoveCandidat(int id);

        bool UpdateCandidat(Candidat model);
       
    }
}

