using DataAccessLayer.Models;
using DataAccessLayer.ProvidedServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class MaterialTypeRepositoryDAL: IMaterialTypeRepositoryDAL
    {
        public DataBaseContext _dbContext;

        public MaterialTypeRepositoryDAL(DataBaseContext context)
        {
            this._dbContext = context;
        }
        public List<MaterialType> GetAllMaterialTypes()
        {
            return this._dbContext.MaterialTypes.ToList();
        }

        public void AddMaterialType(MaterialType materialType)
        {
            _dbContext.MaterialTypes.Add(materialType);
            _dbContext.SaveChanges();
        }

        public bool DeleteMaterialType(long id)
        {
            var existingMaterialType = _dbContext.MaterialTypes.FirstOrDefault(m => m.ID.Equals(id));
            if (existingMaterialType == null) return false;
            _dbContext.Remove(existingMaterialType);
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdateMaterialType(MaterialType materialType)
        {
            var existingMaterialType = _dbContext.MaterialTypes.FirstOrDefault(m => m.ID.Equals(materialType.ID));
            if (existingMaterialType == null) return false;
            existingMaterialType.Name = materialType.Name;
            existingMaterialType.UserMaterialTypes = materialType.UserMaterialTypes;
            _dbContext.Update(existingMaterialType);
            _dbContext.SaveChanges();
            return true;
        }
        public MaterialType GetByID(long id)
        {
            return _dbContext.MaterialTypes.FirstOrDefault(m => m.ID.Equals(id));
        }

        public MaterialType GetByName(string name)
        {
            return _dbContext.MaterialTypes.FirstOrDefault(m => m.Name.Equals(name));
        }
    }
}
