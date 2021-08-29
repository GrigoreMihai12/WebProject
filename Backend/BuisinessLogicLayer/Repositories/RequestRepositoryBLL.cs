using BuisinessLogicLayer.Models;
using BuisinessLogicLayer.ProvidedServices;
using DataAccessLayer.Models;
using DataAccessLayer.ProvidedServices;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisinessLogicLayer.Repositories
{
    public class RequestRepositoryBLL : IRequestRepositoryBLL
    {
        private IRequestRepositoryDAL _requestRepo;
        private Adapter _adapter;
        public RequestRepositoryBLL(IRequestRepositoryDAL requestRepo)
        {
            this._requestRepo = requestRepo;
            this._adapter = new Adapter();
        }

        public List<RequestBLL> GetAllRequests()
        {
            return this._adapter.Adapt<List<RequestBLL>>(this._requestRepo.GetAllRequests());
        }
        public void AddRequest(RequestBLL request)
        {
            var mappedRequest = _adapter.Adapt<Request>(request);
            _requestRepo.AddRequest(mappedRequest);
        }
        public RequestBLL GetByID(long id)
        {
            var mappedRequest = _adapter.Adapt<RequestBLL>(_requestRepo.GetByID(id));
            return mappedRequest;
        }
        public List<RequestBLL> GetByUserID(long id)
        {
            var mappedRequest = _adapter.Adapt<List<RequestBLL>>(_requestRepo.GetByUserID(id));
            return mappedRequest;
        }
        public List<RequestBLL> GetPendingRequestByCenterID(long id)
        {
            var mappedRequest = _adapter.Adapt<List<RequestBLL>>(_requestRepo.GetPendingRequestByCenterID(id));
            return mappedRequest;
        }

        public List<RequestBLL> GetRequestByDate(string date)
        {
            return this._adapter.Adapt<List<RequestBLL>>(this._requestRepo.GetRequestByDate(date));
        }

        public bool UpdateStatus(int id,string status)
        {
            return _requestRepo.UpdateStatus(id, status);
        }
    }
}
