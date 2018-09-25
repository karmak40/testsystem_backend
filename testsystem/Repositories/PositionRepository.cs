using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public Position GetPosition(int id)
        {
            try
            {
                
                var position = MyContext.Positions
                    .Include(pos => pos.Viewers)
                    .Include(pos => pos.Candidats)     // todo in order to show status assesed / not assesed .ThenInclude(can => can.Answers).ThenInclude(ans => ans.Rating)
                    .Include(pos => pos.Tests).FirstOrDefault(x => x.Id == id);
                  

                return position;
                // var pos = MyContext.Positions.Find(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Position GetPositionWithoutIncludes(int id)
        {
            try
            {
                var position = MyContext.Positions.Where(x => x.Id == id).FirstOrDefault();
                return position;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public int AddPosition(Position model)
        {
            try
            {
                MyContext.Positions.Add(model);
                MyContext.SaveChanges();
                var id = model.Id;

                return id;

            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public ICollection<Position> RemovePosition(string id)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePosition(Position model)
        {
            try
            {
                MyContext.Positions.Update(model);
                MyContext.SaveChanges();
                return true;
            } catch (Exception e)
            {
                var message = e.Message;
                return false;
            }
          
        }
    }
}
