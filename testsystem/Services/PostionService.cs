using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testsystem.Interfaces.Repositories;
using testsystem.Interfaces.Services;
using testsystem.models;
using testsystem.Models;
using testsystem.Models.Dto;

namespace testsystem.Services
{
    public class PostionService : IPositionService
    {
        private IPositionRepository _positionRepository;

        public PostionService(IPositionRepository positionRepository)
        {
            this._positionRepository = positionRepository;
        }

        public void GetPosition()
        {
            
        }

        public bool AddPosition(PositionDto dto)
        {
            var model = GetModel(dto);
            return this._positionRepository.AddPosition(model);
        }


        private Position GetModel(PositionDto dto)
        {

            var positionModel = new Position
            {
                Status = dto.Status,
                CloseDate = dto.CloseDate,
                Email = dto.Email,
                Name = dto.Name,
                Number = dto.Number,
                OpenDate = dto.OpenDate,
                Candidats = new List<Candidat>()
            };

            if (dto.Candidats == null) return positionModel;
            foreach (var candidatDto in dto.Candidats)
            {
                var candidatModel = new Candidat
                {
                    Name = candidatDto.Name,
                    Email = candidatDto.Email,
                    ExpiredDate = candidatDto.ExpiredDate,
                    InvitationDate = candidatDto.InvitationDate,
                    Number = candidatDto.Number,
                    Position = positionModel
                };
                positionModel.Candidats.Add(candidatModel);
            }

            if (dto.Viewers == null) return positionModel;

            return positionModel;
        }

        private PositionDto GetDto(Position model)
        {
            return null;
        }


    }
}
