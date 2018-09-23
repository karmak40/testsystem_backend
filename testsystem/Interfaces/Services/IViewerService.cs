using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testsystem.Models.Dto;

namespace testsystem.Interfaces.Services
{
    public interface IViewerService
    {
        bool Add(ViewerDto dto);

        bool Remove(int id);

        bool Update(ViewerDto dto);

         ViewerDto Get(int viewerId);
    }
}
