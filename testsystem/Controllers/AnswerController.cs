using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using testsystem.Interfaces.Services;
using testsystem.Models.Dto;

namespace testsystem.Controllers
{
    [Produces("application/json")]
    [Route("api/Answer")]
    public class AnswerController : Controller
    {

        private readonly IAnswerService _answerService;

        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        // GET: api/Answer
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Answer/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var res = _answerService.GetByRef(id);

            if (res != null)
            {
                return Json(res);
            }
            else
            {
                return StatusCode(500);
            }
        }
        
        // POST: api/Answer
        [HttpPost]
        public IActionResult Post([FromBody] List<AnswerDto> values)
        {
            var res = _answerService.UpdateAnswers(values);

            if (res)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500);
            }
        }
        
        // PUT: api/Answer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
