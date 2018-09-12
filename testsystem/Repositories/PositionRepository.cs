using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testsystem.context;
using testsystem.Interfaces.Repositories;
using testsystem.Interfaces.Services;
using testsystem.Models;
using testsystem.Models.Dto;
using testsystem.Models.Entities;

namespace testsystem.Repositories
{
    public class PositionRepository: IPositionRepository
    {
        private readonly MyContext MyContext;

        public PositionRepository(MyContext myContext)
        {
            this.MyContext = myContext;
        }

        public ICollection<Position> GetPositions()
        {
            try
            {
                return MyContext.Positions.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool AddPosition(Position model)
        {
            try
            {
                MyContext.Positions.Add(model);
                MyContext.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public ICollection<Position> RemovePosition(string id)
        {
            throw new NotImplementedException();
        }
    }
}
