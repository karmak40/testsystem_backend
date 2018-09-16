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

        public ICollection<ViewerDto> Get(int positionId)
        {
            var models = ViewerRepository.Get(positionId);
            var dtos = new List<ViewerDto>();

            foreach (var model in models)
            {
                var dto = this.GetDto(model);
                dtos.Add(dto);
            }
            return dtos;
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
                PositionId = viewerModel.Position.Id
            };
            return viewerDto;
        }

    }
}
