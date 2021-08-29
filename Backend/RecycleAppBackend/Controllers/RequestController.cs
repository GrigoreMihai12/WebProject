using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuisinessLogicLayer.Models;
using BuisinessLogicLayer.ProvidedServices;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecycleAppBackend.Models;
using RecycleAppBackend.Helpers;

namespace RecycleAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {

        private IRequestRepositoryBLL _requestRepo;
        private IUserRepositoryBLL _userRepo;
        private Adapter _adapter;
        public RequestController(IRequestRepositoryBLL requestRepo, IUserRepositoryBLL userRepo)
        {
            this._requestRepo = requestRepo;
            this._userRepo = userRepo;
            this._adapter = new Adapter();
        }
        [HttpGet]
        [Route("GetAllRequests")]
        public IActionResult GetAllRequests()
        {
            return Ok(this._adapter.Adapt<List<RequestViewModel>>(this._requestRepo.GetAllRequests()));
        }
        [HttpPost]
        [Route("AddRequest")]
        public IActionResult AddRequest([FromBody] RequestViewModel request)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _userRepo.GetUserByEmail(request.UserEmail);
                if (existingUser == null) return BadRequest("This user doesn't exist ");

                if (DateTimeHelper.GetDateFromStringFormatYearMonthAndDay(request.Date) < DateTime.Today) return BadRequest("You can't create requests in the past.");

                var mappedRequest = _adapter.Adapt<RequestBLL>(request);
                mappedRequest.IDUser = existingUser.ID;
                _requestRepo.AddRequest(mappedRequest);

                return Ok();
            }

            return BadRequest();
        }
        [HttpPost]
        [Route("GetByID")]
        public IActionResult GetByID([FromBody] int id)
        {
            var mappedRequest = _adapter.Adapt<RequestBLL>(_requestRepo.GetByID(id));
            return Ok(mappedRequest);
        }
        [HttpGet]
        [Route("GetByUserID/{id}")]
        public IActionResult GetByUserID(int id)
        {
            var mappedRequest = _adapter.Adapt<List<RequestViewModel>>(_requestRepo.GetByUserID(id));

            foreach (var item in mappedRequest)
            {
                item.CenterName = _userRepo.GetByID(item.IDCenter)?.Name;
            }

            return Ok(mappedRequest);
        }
        [HttpGet]
        [Route("GetPendingRequestByCenterID/{id}")]
        public IActionResult GetPendingRequestByCenterID(int id)
        {
            var mappedRequest = _adapter.Adapt<List<RequestViewModel>>(_requestRepo.GetPendingRequestByCenterID(id));
            return Ok(mappedRequest);
        }

        [HttpGet]
        [Route("GetRequestByDate")]
        public IActionResult GetRequestByDate(string date)
        {
            return Ok(this._adapter.Adapt<List<RequestViewModel>>(this._requestRepo.GetRequestByDate(date)));
        }
        [HttpPost]
        [Route("AcceptRequest")]
        public IActionResult AcceptRequest([FromBody]int id)
        {
            return Ok(this._requestRepo.UpdateStatus(id,"Accepted"));
        }
        [HttpPost]
        [Route("DeclinedRequest")]
        public IActionResult DeclinedRequest([FromBody] int id)
        {
            return Ok(this._requestRepo.UpdateStatus(id, "Declined"));
        }
    }
}
