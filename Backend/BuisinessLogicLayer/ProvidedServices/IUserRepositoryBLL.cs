using BuisinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisinessLogicLayer.ProvidedServices
{
    public interface IUserRepositoryBLL
    {
        List<UserBLL> GetAllUsers();
        bool Login(UserBLL user);
        void AddUser(UserBLL user);
        bool DeleteUser(int id);
        bool UpdateUser(UserBLL user);
        UserBLL GetByID(long id);
        UserBLL GetUserByEmail(string email);
        List<UserBLL> GetUsersByNeighbourhood(string neighbourhood);
        List<UserBLL> GetUsersByMaterialType(string materialType);
        List<UserBLL> GetUserByType(string type);
    }
}
