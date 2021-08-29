using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace DataAccessLayer.ProvidedServices
{
    public interface IMaterialTypeRepositoryDAL
    {
        List<MaterialType> GetAllMaterialTypes();
        void AddMaterialType(MaterialType materialType);
        bool DeleteMaterialType(long id);
        bool UpdateMaterialType(MaterialType materialType);
        MaterialType GetByID(long id);
        MaterialType GetByName(string name);
    }
}
