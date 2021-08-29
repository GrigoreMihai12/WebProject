using BuisinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisinessLogicLayer.ProvidedServices
{
    public interface IRequestRepositoryBLL
    {
        public List<RequestBLL> GetAllRequests();
        public void AddRequest(RequestBLL request);
        public RequestBLL GetByID(long id);
        public List<RequestBLL> GetByUserID(long id);
        public List<RequestBLL> GetPendingRequestByCenterID(long id);
        public List<RequestBLL> GetRequestByDate(string date);
        public bool UpdateStatus(int id,string status);
    }
}
