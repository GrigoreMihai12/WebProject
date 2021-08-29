using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using RecycleAppBackend.Models;
using BuisinessLogicLayer.ProvidedServices;
using BuisinessLogicLayer.Models;

namespace RecycleAppBackend.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepositoryBLL _userRepo;
        private Adapter _adapter;
        public UserController(IUserRepositoryBLL userRepo)
        {
            this._userRepo = userRepo;
            this._adapter = new Adapter();
        }
        [HttpGet]
        [Route("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            return Ok(this._adapter.Adapt<List<UserViewModel>>(this._userRepo.GetAllUsers()));
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var mappedUser = _adapter.Adapt<UserBLL>(user);
                return Ok(_userRepo.Login(mappedUser));
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser([FromBody] UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _userRepo.GetUserByEmail(user.Email);
                if (existingUser != null) return BadRequest("This user exist already");
                var mappedUser = _adapter.Adapt<UserBLL>(user);
                _userRepo.AddUser(mappedUser);

                return Ok();
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("DeleteUser")]
        public IActionResult DeleteUser([FromBody] int id)
        {

            return Ok(_userRepo.DeleteUser(id));
        }
        [HttpPost]
        [Route("UpdateUser")]
        public IActionResult UpdateUser([FromBody] UserViewModel user)
        {
            var mappedUser = _adapter.Adapt<UserBLL>(user);
            return Ok(_userRepo.UpdateUser(mappedUser));
        }
        [HttpPost]
        [Route("GetByID")]
        public IActionResult GetByID([FromBody] int id)
        {
            var mappedUser = _adapter.Adapt<UserBLL>(_userRepo.GetByID(id));
            return Ok(mappedUser);
        }

        [HttpGet]
        [Route("GetUserByEmail/{email}")]
        public IActionResult GetUserByEmail(string email)
        {
            var mappedUser = _adapter.Adapt<UserBLL>(_userRepo.GetUserByEmail(email));
            return Ok(mappedUser);
        }

        [HttpGet]
        [Route("GetUsersByNeighbourhood/{neighbourhood}")]
        public IActionResult GetUsersByNeighbourhood(string neighbourhood)
        {
            return Ok(this._adapter.Adapt<List<UserViewModel>>(this._userRepo.GetUsersByNeighbourhood(neighbourhood)));
        }

        [HttpGet]
        [Route("GetUsersByMaterialType")]
        public IActionResult GetUsersByMaterialType(string materialType)
        {
            return Ok(this._adapter.Adapt<List<UserViewModel>>(this._userRepo.GetUsersByMaterialType(materialType)));
        }

        [HttpGet]
        [Route("GetUserByType/{type}")]
        public IActionResult GetUserByType(string type)
        {
            return Ok(this._adapter.Adapt<List<UserViewModel>>(this._userRepo.GetUserByType(type)));
        }
    }
}
