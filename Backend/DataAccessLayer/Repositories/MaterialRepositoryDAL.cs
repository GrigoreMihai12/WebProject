using DataAccessLayer.Models;
using DataAccessLayer.ProvidedServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class MaterialRepositoryDAL : IMaterialRepositoryDAL
    {
        public DataBaseContext _dbContext;

        public MaterialRepositoryDAL(DataBaseContext context)
        {
            this._dbContext = context;
        }
        public List<Material> GetAllMaterials()
        {
            return this._dbContext.Materials.ToList();
        }

        public void AddMaterial(Material material)
        {
            _dbContext.Materials.Add(material);
            _dbContext.SaveChanges();
        }

        public bool DeleteMaterial(long id) 
        {
            var existingMaterial = _dbContext.Materials.FirstOrDefault(x => x.ID.Equals(id));
            if (existingMaterial == null) return false;
            _dbContext.Remove(existingMaterial);
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdateMaterial(Material material)
        {
            var existingMaterial = _dbContext.Materials.FirstOrDefault(x => x.ID.Equals(material.ID));
            if (existingMaterial == null) return false;
            existingMaterial.Name = material.Name;
            existingMaterial.Type = material.Type;
            existingMaterial.Separation_Mode = material.Separation_Mode;
            _dbContext.Update(existingMaterial);
            _dbContext.SaveChanges();
            return true;
        }
        public Material GetByID(long id) 
        {
            return _dbContext.Materials.FirstOrDefault(x => x.ID.Equals(id));
        }
        public List<Material> GroupByType(string type)
        {
            var list_material = new List<Material>();
            list_material = _dbContext.Materials.Where(material => material.Type.Equals(type)).ToList();
            return list_material;
        }
    }
}

