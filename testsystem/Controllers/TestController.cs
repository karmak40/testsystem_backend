using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testsystem.Interfaces.Services;
using testsystem.Models.Dto;

namespace testsystem.Controllers
{
    [Produces("application/json")]
    [Route("api/Test")]
    public class TestController : Controller
    {

        private readonly ITestService _testService;
        public TestController(ITestService testService)
        {
            this._testService = testService;

        }

        // GET: api/Test/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var res = this._testService.GetTests(id);
            return Ok(Json(res));
        }
        
        // POST: api/Test
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Test/5
        [HttpPut]
        public IActionResult Put([FromBody]TestDto value)
        {
            var res = this._testService.AddTest(value);

            if (res)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500);
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
