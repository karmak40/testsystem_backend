using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using testsystem.Interfaces.Services;
using testsystem.Models.Dto;

namespace testsystem.Controllers
{
    [Produces("application/json")]
    [Route("api/Position")]
    public class PositionController : Controller
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            this._positionService = positionService;
        }

        // GET: api/Position
        [HttpGet]
        public IActionResult Get()
        {
           return  Json(_positionService.GetPositions());
        }

        // GET: api/Position/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
           // var result = _authorRepository.GetByNameSubstring(namelike);
          //  if (!result.Any())
          //  {
          //      return NotFound(namelike);
           // }
            return Ok();
        }
        
        // POST: api/Position
        [HttpPost]
        public IActionResult Post([FromBody] PositionDto value)
        {
             return _positionService.AddPosition(value) ? Ok() : StatusCode(500);
        }

        // PUT: api/Position/
        [HttpPut]
        public IActionResult Put([FromBody]PositionDto value)
        {
            return _positionService.AddPosition(value) ? Ok() : StatusCode(500);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
