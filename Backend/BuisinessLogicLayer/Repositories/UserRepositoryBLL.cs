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
   public class UserRepositoryBLL : IUserRepositoryBLL
    {
        private IUserRepositoryDAL _userRepo;
        private Adapter _adapter;
        public UserRepositoryBLL(IUserRepositoryDAL userRepo)
        {
            this._userRepo = userRepo;
            this._adapter = new Adapter();
        }

        public List<UserBLL> GetAllUsers()
        {
            return this._adapter.Adapt<List<UserBLL>>(this._userRepo.GetAllUsers());
        }
        public bool Login(UserBLL user)
        {
            var mappedUser = _adapter.Adapt<User>(user);
            return _userRepo.Login(mappedUser);
        }

        public void AddUser(UserBLL user)
        {
            var mappedUser = _adapter.Adapt<User>(user);
            _userRepo.AddUser(mappedUser);
        }
        public bool DeleteUser(int id)
        {
            return _userRepo.DeleteUser(id);
        }
        public bool UpdateUser(UserBLL user)
        {
            var mappedUser = _adapter.Adapt<User>(user);
            return _userRepo.UpdateUser(mappedUser);
        }
        public UserBLL GetByID(long id)
        {
            var mappedUser = _adapter.Adapt<UserBLL>(_userRepo.GetByID(id));
            return mappedUser;
        }
        public UserBLL GetUserByEmail(string email)
        {
            var mappedUser = _adapter.Adapt<UserBLL>(_userRepo.GetUserByEmail(email));
            return mappedUser;
        }

        public List<UserBLL> GetUsersByNeighbourhood(string neighbourhood)
        {
            return this._adapter.Adapt<List<UserBLL>>(this._userRepo.GetUsersByNeighbourhood(neighbourhood));
        }

        public List<UserBLL> GetUsersByMaterialType(string materialType)
        {
            return this._adapter.Adapt<List<UserBLL>>(this._userRepo.GetUsersByMaterialType(materialType));
        }

        public List<UserBLL> GetUserByType(string type) 
        {
            return this._adapter.Adapt<List<UserBLL>>(this._userRepo.GetUserByType(type));
        }
    }
}
