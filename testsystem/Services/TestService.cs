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

        private readonly ITestRepository _testRepository;
        private readonly IPositionRepository _positionRepository;
        private readonly IAnswerService _answerService;
     //   private readonly ICandidatService _candidatService;

        public TestService(ITestRepository testRepository, IPositionRepository positionRepository, IAnswerService answerService)
        {
            this._testRepository = testRepository;
            this._positionRepository = positionRepository;
            this._answerService = answerService;
        //    _candidatService = candidatService;
        }


        public bool AddTest(TestDto dto)
        {
            var model = GetModel(dto);

            var testId = this._testRepository.AddTest(model);
            var answer = true;

            // var tests = GetTests(model.Position.Id);
          //  var candidats = _candidatService.GetCandidats(model.Position.Id);

           
            
            answer = this._answerService.AddAnswerByTest(testId, model.Position.Id);
            

            return answer;
        }

        public ICollection<TestDto> GetTests(int positionId)
        {
            var models = this._testRepository.GetTests(positionId);
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
            return this._testRepository.RemoveTest(id);
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
       
                Number = testDto.Number,
                Time = testDto.Time,
                // Rating
            };
            testModel.Position = this._positionRepository.GetPositionWithoutIncludes(testDto.PositionId);

            return testModel;
        }

        private TestDto GetDto(Test testModel)
        {
            var testDto = new TestDto()
            {
                Id = testModel.Id,
                Name = testModel.Name,
              
                Number = testModel.Number,
                Time = testModel.Time,
                PositionId = testModel.Position.Id
            };
            return testDto;
        }

    }
}
