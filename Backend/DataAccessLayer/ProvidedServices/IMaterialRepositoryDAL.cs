using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.ProvidedServices
{
    public interface IMaterialRepositoryDAL
    {
        List<Material> GetAllMaterials();
        void AddMaterial(Material material);
        bool DeleteMaterial(long id);
        bool UpdateMaterial(Material material);
        Material GetByID(long id);
        List<Material> GroupByType(string type);
    }
}

