using System;
using System.Collections.Generic;
using testsystem.Interfaces.Repositories;
using testsystem.Interfaces.Services;
using testsystem.Models.Dto;
using testsystem.Models.Entities;

namespace testsystem.Services
{
    public class AnswerService: IAnswerService
    {

        private readonly IAnswerRepository _answerRepository;
        private readonly ICandidatRepositories _candidatRepositories;
        private readonly ITestRepository _testRepository;
        private readonly IPositionRepository _positionRepository;
        //private readonly ITestService _testService;


        public AnswerService(IAnswerRepository answerRepository, ICandidatRepositories candidatRepositories, ITestRepository testRepository, IPositionRepository positionRepository)
        {
            _answerRepository = answerRepository;
            _candidatRepositories = candidatRepositories;
            _testRepository = testRepository;
            _positionRepository = positionRepository;
        }

        public bool AddAnswerByTest(int testId, int postionId)
        {
            var answers = new List<Answer>();
            var candidats = _candidatRepositories.GetCandidats(postionId);


            foreach (var can in candidats)
            {
                var ans = new AnswerDto
                {
                    CandidatId = can.Id,
                    TestId = testId,
                    Reference = _answerRepository.FindGuidByCandidat(can.Id) 
                };

                answers.Add(GetModel(ans));
            }

            var res = _answerRepository.AddRange(answers);

            return res;

        }

        public bool AddAnswerByCandidat(int candidatId, int postionId)
        {

            var answers = new List<Answer>();
            var tests = _testRepository.GetTests(postionId);
            var reference = Guid.NewGuid();

            foreach (var test in tests)
              {
                var ans = new AnswerDto
                {
                    CandidatId = candidatId,
                    TestId = test.Id,
                    Reference = reference
                };

                 answers.Add(GetModel(ans));
              }
              var res = _answerRepository.AddRange(answers);
              return res;
              
        }


        public List<AnswerDto> GetByRef(Guid reference)
        {
            var ress =  _answerRepository.GetByRef(reference);
            if (ress == null)
            {
                return null;
            }

            var dtos = new List<AnswerDto>();
            foreach (var mod in ress)
            {
                var dto = GetDto(mod);
                dtos.Add(dto);
            }
            return dtos;    
        }

        private Answer GetModel(AnswerDto answerDto)
        {
            var model = new Answer
            {
                Id = answerDto.Id,
                CandidatId = answerDto.CandidatId,
                Reference = answerDto.Reference,
                TestId = answerDto.TestId,
                Content = answerDto.Content
            };

            return model;
        }

        private AnswerDto GetDto(Answer model)
        {
            var dto = new AnswerDto
            {
                Id = model.Id,
                CandidatId = model.CandidatId,
                Reference = model.Reference,
                TestId = model.TestId,
                Content = model.Content,
                Test = _testRepository.Get(model.TestId).Name
            };

            return dto;
        }

        public bool UpdateAnswers(List<AnswerDto> dtos)
        {
            var models = new List<Answer>();

            foreach(var dto in dtos)
            {
                var model = GetModel(dto);
                models.Add(model);
            }

            var res = _answerRepository.UpdateRange(models);

            return res;

        }
    }
}
