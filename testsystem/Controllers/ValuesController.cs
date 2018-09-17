using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using testsystem.context;
using testsystem.Interfaces.Email;
using testsystem.Interfaces.Services;

namespace testsystem.Controllers
{
    [Route("api/values")]
    public class ValuesController : Controller
    {

        private readonly IPositionService _positionService;
        private readonly IEmailSendService EmailSendService;

        public ValuesController(IPositionService positionService, IEmailSendService emailSendService)
        {
            _positionService = positionService;
            EmailSendService = emailSendService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
          //  this._positionService.AddPosition();
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            BackgroundJob.Schedule(() => EmailSendService.SendMailAction(), 
                TimeSpan.FromMinutes(2));

            return Ok();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
