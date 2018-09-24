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
    public class ViewerService : IViewerService
    {


        private readonly ITestRepository TestRepository;
        private readonly IPositionRepository positionRepository;
        private readonly IViewerRepository ViewerRepository;

        public ViewerService(ITestRepository testRepository, IPositionRepository positionRepository, IViewerRepository viewerRepository)
        {
            this.TestRepository = testRepository;
            this.positionRepository = positionRepository;
            this.ViewerRepository = viewerRepository;
        }

        public bool Add(ViewerDto dto)
        {
            var model = GetModel(dto);
            return this.ViewerRepository.Add(model);
        }

        public ViewerDto Get(int viewerId)
        {
            var model = ViewerRepository.Get(viewerId);

            if (model != null)
            {
                var dto = this.GetDto(model);
                return dto;
            }
            return null;

        }

        public bool Remove(int id)
        {
            return ViewerRepository.Remove(id);
        }

        public bool Update(ViewerDto dto)
        {
            throw new NotImplementedException();
        }


        private Viewer GetModel(ViewerDto viewerDto)
        {
            var viewerModel = new Viewer
            {
                Id = viewerDto.Id,
                Name = viewerDto.Name,
                Email = viewerDto.Email,
                InvitationDate = viewerDto.InvitationDate,
                Number = viewerDto.Number
            };
            viewerModel.Position = this.positionRepository.GetPositionWithoutIncludes(viewerDto.PositionId);

            return viewerModel;
        }

        private ViewerDto GetDto(Viewer viewerModel)
        {
            var viewerDto = new ViewerDto()
            {
                Id = viewerModel.Id,
                Name = viewerModel.Name,
                Email = viewerModel.Email,
                InvitationDate = viewerModel.InvitationDate,
                Number = viewerModel.Number,
                PositionId = viewerModel.Position.Id,
            };
            return viewerDto;
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
                AvailableTime = positionModel.AvailableTime,
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
