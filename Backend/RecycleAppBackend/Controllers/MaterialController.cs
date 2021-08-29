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
    [Route("api/Material")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private IMaterialRepositoryBLL _materialRepo;
        private Adapter _adapter;
        public MaterialController(IMaterialRepositoryBLL materialRepo)
        {
            this._materialRepo = materialRepo;
            this._adapter = new Adapter();
        }
        [HttpGet]
        [Route("GetAllMaterials")]
        public IActionResult GetAllMaterials()
        {
            return Ok(this._adapter.Adapt<List<MaterialViewModel>>(this._materialRepo.GetAllMaterials()));
        }

        [HttpPost]
        [Route("AddMaterial")]
        public IActionResult AddMaterial([FromBody] MaterialViewModel material)
        {
            if (ModelState.IsValid)
            {
                var mappedMaterial = _adapter.Adapt<MaterialBLL>(material);
                _materialRepo.AddMaterial(mappedMaterial);
                return Ok(true);
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("DeleteMaterial")]
        public IActionResult DeleteMaterial([FromBody] long ID)
        {
            return Ok(_materialRepo.DeleteMaterial(ID));
        }
        [HttpPost]
        [Route("UpdateMaterial")]
        public IActionResult UpdateMaterial([FromBody] MaterialViewModel material)
        {
            var mappedmaterial = _adapter.Adapt<MaterialBLL>(material);
            return Ok(_materialRepo.UpdateMaterial(mappedmaterial));
        }
        [HttpPost]
        [Route("GetByID")]
        public IActionResult GetByID([FromBody] long ID)
        {
            var mappedmaterial = _adapter.Adapt<MaterialViewModel>(_materialRepo.GetByID(ID));
            return Ok(mappedmaterial);
        }
        [HttpGet]
        [Route("GroupByType/{type}")]
        public IActionResult GroupByType(string type)
        {
            return Ok(this._adapter.Adapt<List<MaterialViewModel>>(this._materialRepo.GroupByType(type)));
        }
    }
}
