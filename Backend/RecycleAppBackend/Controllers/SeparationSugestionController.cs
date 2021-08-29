using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using RecycleAppBackend.Models;
using BuisinessLogicLayer.ProvidedServices;
using BuisinessLogicLayer.Models;

namespace RecycleAppBackend.Controllers
{
    [Route("api/SeparationSugestion")]
    [ApiController]
    public class SeparationSugestionController : ControllerBase
    {
        private ISeparationSugestionRepositoryBLL _sugestionRepo;
        private Adapter _adapter;
        public SeparationSugestionController(ISeparationSugestionRepositoryBLL sugestionRepo)
        {
            this._sugestionRepo = sugestionRepo;
            this._adapter = new Adapter();
        }
        [HttpGet]
        [Route("GetAllSeparationSugestion")]
        public IActionResult GetAllSeparationSugestion()
        {
            return Ok(this._adapter.Adapt<List<SeparationSugestionViewModel>>(this._sugestionRepo.GetAllSeparationSugestion()));
        }

        [HttpPost]
        [Route("AddSeparationSugestion")]
        public IActionResult AddSeparationSugestion([FromBody] SeparationSugestionViewModel sugestion)
        {
            if (ModelState.IsValid)
            {
                var mappedSeparationSugestion = _adapter.Adapt<SeparationSugestionBLL>(sugestion);
                _sugestionRepo.AddSeparationSugestion(mappedSeparationSugestion);
                return Ok(true);
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("DeleteSeparationSugestion")]
        public IActionResult DeleteSeparationSugestion([FromBody] long ID)
        {
            return Ok(_sugestionRepo.DeleteSeparationSugestion(ID));
        }
        [HttpPost]
        [Route("UpdateSeparationSugestion")]
        public IActionResult UpdateSeparationSugestion([FromBody] SeparationSugestionViewModel sugestion)
        {
            var mappedsugestion = _adapter.Adapt<SeparationSugestionBLL>(sugestion);
            return Ok(_sugestionRepo.UpdateSeparationSugestion(mappedsugestion));
        }
        [HttpPost]
        [Route("GetByID")]
        public IActionResult GetByID([FromBody] long ID)
        {
            var mappedsugestion = _adapter.Adapt<SeparationSugestionViewModel>(_sugestionRepo.GetByID(ID));
            return Ok(mappedsugestion);
        }
    }
}
