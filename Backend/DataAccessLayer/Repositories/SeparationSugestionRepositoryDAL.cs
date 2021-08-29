using DataAccessLayer.Models;
using DataAccessLayer.ProvidedServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class SeparationSugestionRepositoryDAL : ISeparationSugestionRepositoryDAL
    {
        public DataBaseContext _dbContext;

        public SeparationSugestionRepositoryDAL(DataBaseContext context)
        {
            this._dbContext = context;
        }
        public List<SeparationSugestion> GetAllSeparationSugestions()
        {
            return this._dbContext.SeparationSugestion.ToList();
        }

        public void AddSeparationSugestion(SeparationSugestion sugestion)
        {
            _dbContext.SeparationSugestion.Add(sugestion);
            _dbContext.SaveChanges();
        }

        public bool DeleteSeparationSugestion(long id)
        {
            var existingSeparationSugestion = _dbContext.SeparationSugestion.FirstOrDefault(x => x.ID.Equals(id));
            if (existingSeparationSugestion == null) return false;
            _dbContext.Remove(existingSeparationSugestion);
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdateSeparationSugestion(SeparationSugestion sugestion)
        {
            var existingSeparationSugestion = _dbContext.SeparationSugestion.FirstOrDefault(x => x.ID.Equals(sugestion.ID));
            if (existingSeparationSugestion == null) return false;
            existingSeparationSugestion.Name = sugestion.Name;
            existingSeparationSugestion.Description = sugestion.Description;
            _dbContext.Update(existingSeparationSugestion);
            _dbContext.SaveChanges();
            return true;
        }

        public SeparationSugestion GetByID(long id)
        {
            return _dbContext.SeparationSugestion.FirstOrDefault(x => x.ID.Equals(id));
        }
    }
}

