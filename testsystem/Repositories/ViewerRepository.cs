using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testsystem.context;
using testsystem.Interfaces.Repositories;
using testsystem.Models.Entities;

namespace testsystem.Repositories
{
    public class ViewerRepository : IViewerRepository
    {
      
        private readonly MyContext MyContext;

        public ViewerRepository(MyContext myContext)
        {
            this.MyContext = myContext;
        }

        public ICollection<Viewer> Get(int positionId)
        {
            try
            {
                return MyContext.Viewers.Where(pos => pos.Position.Id == positionId).Select(x => x).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public bool Add(Viewer model)
        {
            try
            {
                MyContext.Viewers.Add(model);
                MyContext.SaveChanges();
                var id = model.Id;

                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Remove(int id)
        {
            try
            {

                MyContext.Viewers.Remove(MyContext.Viewers.Find(id));
                MyContext.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(Viewer model)
        {
            try
            {
                MyContext.Viewers.Update(model);
                MyContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                var message = e.Message;
                return false;
            }

        }

    }
}
