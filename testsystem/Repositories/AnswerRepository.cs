using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testsystem.context;
using testsystem.Interfaces.Repositories;
using testsystem.Models.Dto;
using testsystem.Models.Entities;

namespace testsystem.Repositories
{
    public class AnswerRepository: IAnswerRepository
    {

        private readonly MyContext MyContext;

        public AnswerRepository(MyContext myContext)
        {
            MyContext = myContext;
        }

        public bool Add(Answer model)
        {
            throw new NotImplementedException();
        }

        public bool AddRange(List<Answer> models)
        {
            try
            {
                MyContext.Answers.AddRange(models);
                MyContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Answer GetByRef(Guid reference)
        {
            throw new NotImplementedException();
        }

        public List<Answer> GetExisting(List<TestDto> tests, List<CandidatDto> candidats)
        {
            return null;
        }

        public Guid FindGuidByCandidat(int candidatId)
        {
            try
            {
                var reference = MyContext.Answers.Where(ans => ans.CandidatId == candidatId).Select(x => x.Reference).FirstOrDefault();

                if (reference == Guid.Empty)
                {
                    return Guid.NewGuid();
                }
                return reference;
            }
            catch (Exception e)
            {
                return Guid.Empty;
            }
        }
    }
}
