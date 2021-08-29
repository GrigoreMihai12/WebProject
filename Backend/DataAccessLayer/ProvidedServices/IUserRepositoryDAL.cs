using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.ProvidedServices
{
    public interface IUserRepositoryDAL
    {
        List<User> GetAllUsers();
        bool Login(User user);
        void AddUser(User user);
        bool DeleteUser(int id);
        bool UpdateUser(User user);
        User GetByID(long id);
        User GetUserByEmail(string email);
        List<User> GetUsersByNeighbourhood(string neighbourhood);
        List<User> GetUsersByMaterialType(string materialType);
        List<User> GetUserByType(string type);
    }
}
