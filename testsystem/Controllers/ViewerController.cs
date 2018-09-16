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
    [Route("api/Viewer")]
    public class ViewerController : Controller
    {
        private readonly IViewerService _viewerService;
        public ViewerController(IViewerService viewerService)
        {
            this._viewerService = viewerService;

        }

        // GET: api/Viewer/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var res = this._viewerService.Get(id);
            return Ok(Json(res));
        }

        // POST: api/Viewer
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Viewer/
        [HttpPut]
        public IActionResult Put([FromBody]ViewerDto value)
        {
            var res = this._viewerService.Add(value);

            if (res)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500);
            }
        }

        // DELETE: api/Viewer/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
