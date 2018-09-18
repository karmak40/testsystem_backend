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

            return GetDto(position);  //.ToList();
        }


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

        public bool UpdatePosition(PositionDto dto)
        {
            var model = GetModel(dto);
            return this._positionRepository.UpdatePosition(model);
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
                Instruction = "This is instruction to this interview",
                CompanyInfo = "this will be another long text loaded from some source"
            };
            return defaultModel;
        }


        private Position GetModel(PositionDto dto)
        {

            var positionModel = new Position
            {
                Id = dto.Id,
                Status = dto.Status,
                CloseDate = dto.CloseDate,
                Name = dto.Name,
                Number = dto.Number,
                OpenDate = dto.OpenDate,
                About = dto.About,
                CompanyInfo = dto.CompanyInfo,
                Instruction = dto.Instruction,
                Candidats = new List<Candidat>(),
                Tests = new List<Test>(),
                Viewers = new List<Viewer>(),
            };

            if (positionModel.Tests != null)
            {
                foreach (var testDto in dto.Tests)
                {
                    var modelTest = new Test()
                    {
                        Id = testDto.Id,
                        Name = testDto.Name,
                        Number = testDto.Number,
                        Time = testDto.Time,
                        Position = positionModel,
                        Answers = new List<Answer>(),
                        //Rating = new List<Rating>(),
                    };
                    positionModel.Tests.Add(modelTest);
                }
            }

            if (dto.Candidats != null)
            {
                foreach (var candidatDto in dto.Candidats)
                {
                    var candidatModel = new Candidat
                    {
                        Id = candidatDto.Id,
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
                About = positionModel.About,
                Instruction = positionModel.Instruction,
                CompanyInfo = positionModel.CompanyInfo,
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
                About = positionModel.About,
                CompanyInfo = positionModel.CompanyInfo,
                Number = positionModel.Number,
                Instruction = positionModel.Instruction,
                OpenDate = positionModel.OpenDate,
                Viewers = new List<ViewerDto>(),
                Candidats = new List<CandidatDto>(),
                Tests = new List<TestDto>()
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
                        Phone = candidatModel.Phone,
                        PositionId = positionDto.Id,
                    };
                    positionDto.Candidats.Add(candidatDto);
          
                }
            }


            if (positionModel.Tests != null)
            {
                foreach (var testModel in positionModel.Tests)
                {
                    var testDto = new TestDto()
                    {
                        Id = testModel.Id,
                        Name = testModel.Name,
                        Number = testModel.Number,
                        Time = testModel.Time,
                        PositionId = testModel.Position.Id,
                        Answers = new List<AnswerDto>(),
                    };
                    positionDto.Tests.Add(testDto);
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
