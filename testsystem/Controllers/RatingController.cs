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
    [Route("api/Rating")]
    public class RatingController : Controller
    {

        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingRatingService)
        {
            _ratingService = ratingRatingService;
        }

        // GET: api/Rating
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Rating/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Rating
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Rating/5
        [HttpPut]
        public IActionResult Put([FromBody]List<RatingDto> dtos)
        {
            var res = _ratingService.AddRange(dtos);

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
