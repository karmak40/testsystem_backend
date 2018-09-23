using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testsystem.Models.Entities;

namespace testsystem.Interfaces.Repositories
{
    public interface IViewerRepository
    {
        Viewer Get(int viewerId);

        bool Add(Viewer model);

        bool Remove(int id);

        bool Update(Viewer model);
    }
}
