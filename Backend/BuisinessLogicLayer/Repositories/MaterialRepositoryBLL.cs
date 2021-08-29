using BuisinessLogicLayer.Models;
using BuisinessLogicLayer.ProvidedServices;
using DataAccessLayer.ProvidedServices;
using System;
using System.Collections.Generic;
using System.Text;
using Mapster;
using DataAccessLayer.Models;

namespace BuisinessLogicLayer.Repositories
{
    public class MaterialRepositoryBLL : IMaterialRepositoryBLL
    {
        private IMaterialRepositoryDAL _materialRepo;
        private Adapter _adapter;
        public MaterialRepositoryBLL(IMaterialRepositoryDAL materialRepo)
        {
            this._materialRepo = materialRepo;
            this._adapter = new Adapter();
        }

        public List<MaterialBLL> GetAllMaterials()
        {
            return this._adapter.Adapt<List<MaterialBLL>>(this._materialRepo.GetAllMaterials());
        }
        public void AddMaterial(MaterialBLL material)
        {
            var mappedMaterial = _adapter.Adapt<Material>(material);
            _materialRepo.AddMaterial(mappedMaterial);
        }
        public bool DeleteMaterial(long id)
        {
            return _materialRepo.DeleteMaterial(id);
        }
        public bool UpdateMaterial(MaterialBLL material)
        {
            var mappedMaterial = _adapter.Adapt<Material>(material);
            return _materialRepo.UpdateMaterial(mappedMaterial);
        }
        public MaterialBLL GetByID(long id)
        {
            var mappedMaterial = _adapter.Adapt<MaterialBLL>(_materialRepo.GetByID(id));
            return mappedMaterial;
        }
        public List<MaterialBLL> GroupByType(string type)
        {
            var mappedMaterial = _adapter.Adapt<List<MaterialBLL>>(_materialRepo.GroupByType(type));
            return mappedMaterial;
        }
    }
}
