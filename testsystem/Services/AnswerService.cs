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
    public class AnswerService: IAnswerService
    {

        private readonly IAnswerRepository _answerRepository;
 

        public AnswerService(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public bool Add(int testId, List<CandidatDto> candidats)
        {
            var answers = new List<Answer>();


            foreach (var can in candidats)
            {
                var ans = new AnswerDto
                {
                    CandidatId = can.Id,
                    TestId = testId,
                    Reference =  _answerRepository.FindGuidByCandidat(can.Id)   // Guid.NewGuid()
                };

                answers.Add(GetModel(ans));
            }
         
            var res = _answerRepository.AddRange(answers);

            return res;
        }

        public AnswerDto GetByRef(Guid reference)
        {
            throw new NotImplementedException();
        }

        private Answer GetModel(AnswerDto answerDto)
        {
            var model = new Answer
            {
                CandidatId = answerDto.CandidatId,
                Reference = answerDto.Reference,
                TestId = answerDto.TestId
            };

            return model;
        }
    }
}
