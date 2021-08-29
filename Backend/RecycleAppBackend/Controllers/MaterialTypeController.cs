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
    [Route("api/MaterialType")]
    [ApiController]
    public class MaterialTypeController : ControllerBase
    {
        private IMaterialTypeRepositoryBLL _materialTypeRepository;
        private Adapter _adapter;
        public MaterialTypeController(IMaterialTypeRepositoryBLL materialTypeRepository)
        {
            this._materialTypeRepository = materialTypeRepository;
            this._adapter = new Adapter();
        }
        [HttpGet]
        [Route("GetAllMaterialTypes")]
        public IActionResult GetAllMaterials()
        {
            return Ok(this._adapter.Adapt<List<MaterialTypeViewModel>>(this._materialTypeRepository.GetAllMaterialTypes()));
        }

        [HttpPost]
        [Route("AddMaterialType")]
        public IActionResult AddMaterialType([FromBody] MaterialTypeViewModel materialType)
        {
            if (ModelState.IsValid)
            {
                var mappedMaterialType = _adapter.Adapt<MaterialTypeBLL>(materialType);
                _materialTypeRepository.AddMaterialType(mappedMaterialType);
                return Ok(true);
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("DeleteMaterialType")]
        public IActionResult DeleteMaterialType([FromBody] long ID)
        {
            return Ok(_materialTypeRepository.DeleteMaterialType(ID));
        }
        [HttpPost]
        [Route("UpdateMaterialType")]
        public IActionResult UpdateMaterial([FromBody] MaterialTypeViewModel materialType)
        {
            var mappedMaterialType = _adapter.Adapt<MaterialTypeBLL>(materialType);
            return Ok(_materialTypeRepository.UpdateMaterialType(mappedMaterialType));
        }
        [HttpPost]
        [Route("GetByID")]
        public IActionResult GetByID([FromBody] long ID)
        {
            var mappedmaterialType = _adapter.Adapt<MaterialTypeViewModel>(_materialTypeRepository.GetByID(ID));
            return Ok(mappedmaterialType);
        }

        [HttpPost]
        [Route("GetByName")]
        public IActionResult GetByName([FromBody] string name)
        {
            var mappedmaterialType = _adapter.Adapt<MaterialTypeViewModel>(_materialTypeRepository.GetByName(name));
            return Ok(mappedmaterialType);
        }
    }
}
