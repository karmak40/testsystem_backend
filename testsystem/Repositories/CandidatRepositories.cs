using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testsystem.context;
using testsystem.Interfaces.Repositories;
using testsystem.Models.Entities;

namespace testsystem.Repositories
{
    public class CandidatRepositories: ICandidatRepositories
    {

        private readonly MyContext MyContext;

        public CandidatRepositories(MyContext myContext)
        {
            this.MyContext = myContext;
        }

        public ICollection<Candidat> GetCandidats(int positionId)
        {
            try
            {
                return MyContext.Candidats.Where(pos => pos.Position.Id == positionId).Select(x => x).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Candidat GetCandidat(int id)
        {
            try
            {
                // return MyContext.Candidats.FirstOrDefault(can => can.Id == id);
                var position = MyContext.Candidats
                     .Include(can => can.Answers).FirstOrDefault(x => x.Id == id);
                return position;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public int AddCandidat(Candidat model)
        {
            try
            {
                MyContext.Candidats.Add(model);
                MyContext.SaveChanges();
                var id = model.Id;

                return id;

            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public bool RemoveCandidat(int id)
        {
            try
            {

                MyContext.Candidats.Remove(MyContext.Candidats.Find(id));
                MyContext.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UpdateCandidat(Candidat model)
        {
            try
            {
                MyContext.Candidats.Update(model);
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

