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
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var positionDto = _positionService.GetPosition(id);
            if (positionDto != null)
            {
                return Ok(positionDto);
            }
            else
            {
                return StatusCode(500);
            }
        }
        
        // POST: api/Position
        [HttpPost]
        public IActionResult Post([FromBody] PositionDto value)
        {
            var res = _positionService.UpdatePosition(value);
            if (res)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500);
            }
        }

        // PUT: api/Position/
        [HttpPut]
        public IActionResult Put()
        {
            var id = _positionService.AddPosition();
            if (id > 0)
            {
                return Ok(id);
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
