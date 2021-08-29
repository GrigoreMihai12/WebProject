using System;
using System.Collections.Generic;
using System.Text;
using BuisinessLogicLayer.Models;

namespace BuisinessLogicLayer.ProvidedServices
{
    public interface ISeparationSugestionRepositoryBLL
    {
        List<SeparationSugestionBLL> GetAllSeparationSugestion();
        void AddSeparationSugestion(SeparationSugestionBLL sugestion);
        bool DeleteSeparationSugestion(long id);
        bool UpdateSeparationSugestion(SeparationSugestionBLL sugestion);
        SeparationSugestionBLL GetByID(long id);
    }
}
