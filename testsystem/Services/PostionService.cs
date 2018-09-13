using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using testsystem.Interfaces.Repositories;
using testsystem.Interfaces.Services;
using testsystem.Models;
using testsystem.Models.Dto;
using testsystem.Models.Entities;

namespace testsystem.Services
{
    public class PostionService : IPositionService
    {
        private IPositionRepository _positionRepository;

        public PostionService(IPositionRepository positionRepository)
        {
            this._positionRepository = positionRepository;
        }

        public PositionDto GetPosition(int id)
        {
            var position = this._positionRepository.GetPosition(id);

            return GetPositionDto(position);  //.ToList();
        }

        /*
         * [
                {
                    "id": 1,
                    "name": "Head of Operation",
                    "openDate": 3123213213122,
                    "closeDate": 123124234332,
                    "status": "Opened",
                    "email": "Jacn@mail.ru",
                    "number": 1312,
                    "candidats": [],
                    "viewers": []
                },
                {
                    "id": 2,
                    "name": "Head of Operation",
                    "openDate": 3123213213122,
                    "closeDate": 123124234332,
                    "status": "Opened",
                    "email": "Jacn@mail.ru",
                    "number": 1312,
                    "candidats": [],
                    "viewers": []
                }
            ]
         */

        public ICollection<PositionDto> GetPositions()
        {
            var positionModels = this._positionRepository.GetPositions();
            return positionModels.Select(GetPositionDto).ToList();
            // return positionModels.Select(GetDto).ToList();
        }

        public int AddPosition(PositionDto dto)
        {
            var model = GetModel(dto);
            return this._positionRepository.AddPosition(model);
        }

        public int AddPosition()
        {
            var model = GetDefaultModel();
            return this._positionRepository.AddPosition(model);
        }

        private Position GetDefaultModel()
        {
            var defaultModel = new Position
            {
                Status = "Planned",
                CloseDate = 0,
                Name = "Default",
                Number = "0",
                OpenDate = 0,
                About = "this will be a long text loaded from some source",
                CompanyInfo = "this will be another long text loaded from some source"
            };
            return defaultModel;
        }


        private Position GetModel(PositionDto dto)
        {

            var positionModel = new Position
            {
                Status = dto.Status,
                CloseDate = dto.CloseDate,
                Name = dto.Name,
                Number = dto.Number,
                OpenDate = dto.OpenDate,
                Candidats = new List<Candidat>()
            };

            if (dto.Candidats != null)
            {
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
            }

            if (dto.Viewers == null) return positionModel;
            foreach (var viewertDto in dto.Viewers)
            {
                var viewerModel = new Viewer()
                {
                    Name = viewertDto.Name,
                    Email = viewertDto.Email,
                    InvitationDate = viewertDto.InvitationDate,
                    Number = viewertDto.Number,
                    Position = positionModel
                };
                positionModel.Viewers.Add(viewerModel);
            }

            return positionModel;
        }

        private PositionDto GetPositionDto(Position positionModel)
        {
            var positionDto = new PositionDto()
            {
                Id = positionModel.Id,
                Status = positionModel.Status,
                CloseDate = positionModel.CloseDate,
                Name = positionModel.Name,
                Number = positionModel.Number,
                OpenDate = positionModel.OpenDate,
            };
            return positionDto;
        }


        private PositionDto GetDto(Position positionModel)
        {
            var positionDto = new PositionDto()
            {
                Id = positionModel.Id,
                Status = positionModel.Status,
                CloseDate = positionModel.CloseDate,
                Name = positionModel.Name,
                Number = positionModel.Number,
                OpenDate = positionModel.OpenDate,
                Viewers = new List<ViewerDto>(),
                Candidats = new List<CandidatDto>()
            };

            if (positionModel.Candidats != null)
            {
                foreach (var candidatModel in positionModel.Candidats)
                {
                    var candidatDto = new CandidatDto()
                    {
                        Id = candidatModel.Id,
                        Name = candidatModel.Name,
                        Email = candidatModel.Email,
                        ExpiredDate = candidatModel.ExpiredDate,
                        InvitationDate = candidatModel.InvitationDate,
                        Number = candidatModel.Number,
                    };
                    positionDto.Candidats.Add(candidatDto);
                }
            }

            if (positionModel.Viewers == null) return positionDto;
            foreach (var viewerModel in positionModel.Viewers)
            {
                var viewertDto = new ViewerDto()
                {
                    Id = viewerModel.Id,
                    Name = viewerModel.Name,
                    Email = viewerModel.Email,
                    Number = viewerModel.Number,
                    InvitationDate = viewerModel.InvitationDate,

                };
                positionDto.Viewers.Add(viewertDto);
            }

            return positionDto;
        }

    }
}
