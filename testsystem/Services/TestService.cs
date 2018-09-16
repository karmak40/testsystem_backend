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
    public class TestService : ITestService
    {

        private readonly ITestRepository TestRepository;
        private readonly IPositionRepository positionRepository;

        public TestService(ITestRepository testRepository, IPositionRepository positionRepository)
        {
            this.TestRepository = testRepository;
            this.positionRepository = positionRepository;
        }


        public bool AddTest(TestDto dto)
        {
            var model = GetModel(dto);
            return this.TestRepository.AddTest(model);
        }

        public ICollection<TestDto> GetTests(int positionId)
        {
            var models = this.TestRepository.GetTests(positionId);
            var dtos = new List<TestDto>();

            foreach (var model in models)
            {
                var dto = this.GetDto(model);
                dtos.Add(dto);
            }
            return dtos;
        }

        public bool RemoveTest(int id)
        {
            return this.TestRepository.RemoveTest(id);
        }

        public bool UpdateTest(TestDto dto)
        {
            throw new NotImplementedException();
        }


        private Test GetModel(TestDto testDto)
        {
            var testModel = new Test
            {
                Name = testDto.Name,
                Answer = testDto.Answer,
                Number = testDto.Number,
                Time = testDto.Time,
                // Rating
            };
            testModel.Position = this.positionRepository.GetPositionWithoutIncludes(testDto.PositionId);

            return testModel;
        }

        private TestDto GetDto(Test testModel)
        {
            var testDto = new TestDto()
            {
                Id = testModel.Id,
                Name = testModel.Name,
                Answer = testModel.Answer,
                Number = testModel.Number,
                Time = testModel.Time,
                PositionId = testModel.Position.Id
            };
            return testDto;
        }

    }
}
