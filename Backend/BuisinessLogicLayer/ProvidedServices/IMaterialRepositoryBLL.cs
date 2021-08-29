using BuisinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisinessLogicLayer.ProvidedServices
{
    public interface IMaterialRepositoryBLL
    {
        List<MaterialBLL> GetAllMaterials();
        void AddMaterial(MaterialBLL material);
        bool DeleteMaterial(long id);
        bool UpdateMaterial(MaterialBLL material);
        MaterialBLL GetByID(long id);
        List<MaterialBLL> GroupByType(string type);
    }
}
