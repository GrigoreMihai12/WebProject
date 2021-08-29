using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.ProvidedServices
{
   public  interface IRequestRepositoryDAL
    {
        public List<Request> GetAllRequests();
        public void AddRequest(Request request);
        public Request GetByID(long id);
        public List<Request> GetByUserID(long id);
        public List<Request> GetPendingRequestByCenterID(long id);
        public List<Request> GetRequestByDate(string date);
        public bool UpdateStatus(int id, string status);
    }
}
