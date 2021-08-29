using DataAccessLayer.Models;
using DataAccessLayer.ProvidedServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repositories
{
    public class RequestRepositoryDAL : IRequestRepositoryDAL
    {
        public DataBaseContext _dbContext;

        public RequestRepositoryDAL(DataBaseContext context)
        {
            this._dbContext = context;
        }

        public List<Request> GetAllRequests()
        {
            return this._dbContext.Requests.ToList();
        }
        public void AddRequest(Request request)
        {
            _dbContext.Requests.Add(request);
            _dbContext.SaveChanges();
        }
        public Request GetByID(long id)
        {
            return _dbContext.Requests.FirstOrDefault(x => x.ID.Equals(id));
        }
        public List<Request> GetByUserID(long id)
        {
            var requests = new List<Request>();
            requests = _dbContext.Requests.Where(x => x.IDUser.Equals(id)).ToList();
            return requests;
        }
        public List<Request> GetPendingRequestByCenterID(long id)
        {
            var requests = new List<Request>();
            requests = _dbContext.Requests.ToList().Where(x => x.IDCenter.Equals(id)&& x.Status.Equals("Pending")).ToList();
            return requests;
        }
        public List<Request> GetRequestByDate(string date)
        {
            var requests = new List<Request>();
            requests = _dbContext.Requests.Where(x => x.Date.Equals(date)).ToList();
            return requests;
        }

        public bool UpdateStatus(int id, string status) 
        {
            var existRequest = _dbContext.Requests.FirstOrDefault(x => x.ID.Equals(id));
            if (existRequest == null) return false;
            existRequest.Status = status;
            _dbContext.Requests.Update(existRequest);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
