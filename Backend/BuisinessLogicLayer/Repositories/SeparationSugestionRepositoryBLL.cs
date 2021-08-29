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
    public class SeparationSugestionRepositoryBLL : ISeparationSugestionRepositoryBLL
    {
        private ISeparationSugestionRepositoryDAL _sugestionRepo;
        private Adapter _adapter;
        public SeparationSugestionRepositoryBLL(ISeparationSugestionRepositoryDAL sugestionRepo)
        {
            this._sugestionRepo = sugestionRepo;
            this._adapter = new Adapter();
        }

        public List<SeparationSugestionBLL> GetAllSeparationSugestion()
        {
            return this._adapter.Adapt<List<SeparationSugestionBLL>>(this._sugestionRepo.GetAllSeparationSugestions());
        }
        public void AddSeparationSugestion(SeparationSugestionBLL sugestion)
        {
            var mappedSeparationSugestion = _adapter.Adapt<SeparationSugestion>(sugestion);
            _sugestionRepo.AddSeparationSugestion(mappedSeparationSugestion);
        }
        public bool DeleteSeparationSugestion(long id)
        {
            return _sugestionRepo.DeleteSeparationSugestion(id);
        }
        public bool UpdateSeparationSugestion(SeparationSugestionBLL sugestion)
        {
            var mappedSeparationSugestion = _adapter.Adapt<SeparationSugestion>(sugestion);
            return _sugestionRepo.UpdateSeparationSugestion(mappedSeparationSugestion);
        }
        public SeparationSugestionBLL GetByID(long id)
        {
            var mappedSeparationSugestion = _adapter.Adapt<SeparationSugestionBLL>(_sugestionRepo.GetByID(id));
            return mappedSeparationSugestion;
        }

    }
}

