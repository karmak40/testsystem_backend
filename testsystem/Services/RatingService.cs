using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testsystem.Interfaces.Repositories;
using testsystem.Interfaces.Services;
using testsystem.Models.Dto;
using testsystem.Models.Entities;

namespace testsystem.Services
{
    public class RatingService: IRatingService
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingService(IRatingRepository ratingRepository)
        {
            this._ratingRepository = ratingRepository;
        }

        public bool Add(RatingDto dto)
        {
            var model = GetModel(dto);

            var ratingId = this._ratingRepository.Add(model);

            return ratingId > 0;
        }

        public bool AddRange(List<RatingDto> dtos)
        {
            var models = new List<Rating>();

            foreach (var dto in dtos)
            {
                models.Add(GetModel(dto));
            }

            var res = _ratingRepository.AddRange(models);
            return res;
        }

        public bool RemoveTest(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTest(RatingDto dto)
        {
            throw new NotImplementedException();
        }

        public RatingDto Get(int ratingId)
        {
            var model = _ratingRepository.Get(ratingId);

            return model != null ? GetDto(model) : null;
        }

        public ICollection<RatingDto> GetRatings(int answerId)
        {
            var models = _ratingRepository.GetRatingsByAnswerId(answerId);
           // var dtos = new List<RatingDto>();

            /*foreach (var rating in models)
            {
               var dto = GetDto(rating);
                dtos.Add(dto);
            }*/

            return models.Select(GetDto).ToList();
        }

        private static Rating GetModel(RatingDto dto)
        {
            var model = new Rating
            {
                Grade = dto.Grade,
                Number = dto.Number,
                AnswerId = dto.AnswerId,
                ViewerId = dto.ViewerId,
                Id = dto.Id,
            };
            return model;
        }

        private static RatingDto GetDto(Rating model)
        {
            var dto = new RatingDto()
            {
                Grade = model.Grade,
                Number = model.Number,
                AnswerId = model.AnswerId,
                ViewerId = model.ViewerId,
                Id = model.Id
            };
            return dto;
        }


    }
}

