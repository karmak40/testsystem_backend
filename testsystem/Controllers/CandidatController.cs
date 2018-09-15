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
    [Route("api/Candidat")]
    public class CandidatController : Controller
    {

        private readonly ICandidatService CandidatService;
        public CandidatController(ICandidatService candidatService)
        {
           this.CandidatService = candidatService;
           
        }

        // GET: api/Candidat/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var res = this.CandidatService.GetCandidats(id);
            return Json(res);

        }
        
        // POST: api/Candidat
        [HttpPost]
        public void Post([FromBody]CandidatDto dto)
        {
            this.CandidatService.AddCandidat(dto);
        }
        
        // PUT: api/Candidat/
        [HttpPut]
        public IActionResult Put([FromBody]CandidatDto value)
        {
            var res = this.CandidatService.AddCandidat(value);

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
