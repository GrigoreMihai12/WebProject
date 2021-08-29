using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.ProvidedServices
{
    public interface ISeparationSugestionRepositoryDAL
    {
        List<SeparationSugestion> GetAllSeparationSugestions();
        void AddSeparationSugestion(SeparationSugestion sugestion);
        bool DeleteSeparationSugestion(long id);
        bool UpdateSeparationSugestion(SeparationSugestion sugestion);
        SeparationSugestion GetByID(long id);
    }
}


