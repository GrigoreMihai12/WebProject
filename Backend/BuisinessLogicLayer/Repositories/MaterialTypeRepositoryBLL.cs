using BuisinessLogicLayer.Models;
using BuisinessLogicLayer.ProvidedServices;
using DataAccessLayer.Models;
using DataAccessLayer.ProvidedServices;
using System;
using System.Collections.Generic;
using System.Text;
using Mapster;


namespace BuisinessLogicLayer.Repositories
{
    public class MaterialTypeRepositoryBLL : IMaterialTypeRepositoryBLL
    {
        private IMaterialTypeRepositoryDAL _materialTypeRepository;
        private Adapter _adapter;
        public MaterialTypeRepositoryBLL(IMaterialTypeRepositoryDAL materialTypeRepository)
        {
            this._materialTypeRepository = materialTypeRepository;
            this._adapter = new Adapter();
        }

        public List<MaterialTypeBLL> GetAllMaterialTypes()
        {
            return this._adapter.Adapt<List<MaterialTypeBLL>>(this._materialTypeRepository.GetAllMaterialTypes());
        }
        public void AddMaterialType(MaterialTypeBLL materialType)
        {
            var mappedMaterialType = _adapter.Adapt<MaterialType>(materialType);
            _materialTypeRepository.AddMaterialType(mappedMaterialType);
        }
        public bool DeleteMaterialType(long id)
        {
            return _materialTypeRepository.DeleteMaterialType(id);
        }
        public bool UpdateMaterialType(MaterialTypeBLL materialType)
        {
            var mappedMaterialType = _adapter.Adapt<MaterialType>(materialType);
            return _materialTypeRepository.UpdateMaterialType(mappedMaterialType);
        }
        public MaterialTypeBLL GetByID(long id)
        {
            var mappedMaterialType = _adapter.Adapt<MaterialTypeBLL>(_materialTypeRepository.GetByID(id));
            return mappedMaterialType;
        }

        public MaterialTypeBLL GetByName(string name)
        {
            var mappedMaterialType = _adapter.Adapt<MaterialTypeBLL>(_materialTypeRepository.GetByName(name));
            return mappedMaterialType;
        }

    }
}
