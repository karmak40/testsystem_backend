using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testsystem.context;
using testsystem.Interfaces.Repositories;
using testsystem.Models.Entities;

namespace testsystem.Repositories
{
    public class RatingRepository: IRatingRepository
    {

        private readonly MyContext _myContext;

        public RatingRepository(MyContext myContext)
        {
            this._myContext = myContext;
        }

        public ICollection<Rating> GetRatingsByAnswerId(int answerId)
        {
            try
            {
                var rating = _myContext.Ratings.Where(x => x.AnswerId == answerId).Select(x => x).ToList();
                return rating;
            }
            catch (Exception e)
            {
                var message = e.Message;
                return null;
            }
        }

        public ICollection<Rating> GetRatingsByViewerId(int viewerId)
        {
            try
            {
                var rating = _myContext.Ratings.Where(x => x.ViewerId == viewerId).Select(x => x).ToList();
                return rating;
            }
            catch (Exception e)
            {
                var message = e.Message;
                return null;
            }
        }

        public bool AddRange(List<Rating> models)
        {
            try
            {
                _myContext.Ratings.UpdateRange(models);
                _myContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                var message = e.Message;
                return false;
            }
        }

        public Rating Get(int ratingId)
        {
            try
            {
                var rating = _myContext.Ratings.FirstOrDefault(x => x.Id == ratingId);
                _myContext.SaveChanges();
                return rating;
            }
            catch (Exception e)
            {
                var message = e.Message;
                return null;
            }
        }

        public int Add(Rating model)
        {
            try
            {
                _myContext.Ratings.Add(model);
                _myContext.SaveChanges();
                var id = model.Id;
                return id;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public bool Remove(int id)
        {
            try
            {
                _myContext.Ratings.Remove(_myContext.Ratings.Find(id));
                _myContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(Rating model)
        {
            throw new NotImplementedException();
        }
    }
}
