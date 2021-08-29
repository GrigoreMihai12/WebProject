using BuisinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisinessLogicLayer.ProvidedServices
{
    public interface IMaterialTypeRepositoryBLL
    {
        List<MaterialTypeBLL> GetAllMaterialTypes();
        void AddMaterialType(MaterialTypeBLL materialType);
        bool DeleteMaterialType(long id);
        bool UpdateMaterialType(MaterialTypeBLL materialType);
        MaterialTypeBLL GetByID(long id);
        MaterialTypeBLL GetByName(string name);
    }
}
