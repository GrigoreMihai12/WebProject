using DataAccessLayer.Models;
using DataAccessLayer.ProvidedServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class UserRepositoryDAL : IUserRepositoryDAL
    {
        public DataBaseContext _dbContext;

        public UserRepositoryDAL(DataBaseContext context)
        {
            this._dbContext = context;
        }
        public List<User> GetAllUsers()
        {
            return this._dbContext.Users.ToList();
        }
        public bool Login(User user)
        {
            var existingUser = _dbContext.Users.FirstOrDefault(x => x.Email.Equals(user.Email));

            if (existingUser == null) return false;
            if (existingUser.Password.Equals(user.Password)) return true;
            return false;
        }
        public void AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }
        public bool DeleteUser(int id)
        {
            var existingUser = _dbContext.Users.FirstOrDefault(x => x.ID.Equals(id));
            if (existingUser == null) return false;
            _dbContext.Remove(existingUser);
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdateUser(User user)
        {
            var existingUser = _dbContext.Users.FirstOrDefault(x => x.ID.Equals(user.ID));
            if (existingUser == null) return false;
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.Address = user.Address;
            existingUser.Password = user.Password;
            _dbContext.Update(existingUser);

            if (user.UserMaterialTypes != null)
            {

                var existingUserMaterialTypes = _dbContext.UserMaterialTypes.Where(x => x.UserId == existingUser.ID);
                _dbContext.UserMaterialTypes.RemoveRange(existingUserMaterialTypes);

                foreach (var item in user.UserMaterialTypes)
                {
                    _dbContext.UserMaterialTypes.Add(new UserMaterialType() { UserId = existingUser.ID, MaterialTypeId = item.MaterialTypeId });
                }

            }

            _dbContext.SaveChanges();
            return true;
        }

        public User GetByID(long id)
        {
            return _dbContext.Users.FirstOrDefault(x => x.ID.Equals(id));
        }

        public User GetUserByEmail(string email)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Email.Equals(email));
        }

        public List<User> GetUsersByNeighbourhood(string neighbourhood)
        {
            var users = new List<User>();
            users = _dbContext.Users.Where(x => x.Neighbourhood.Equals(neighbourhood)).ToList();

            foreach (var user in users)
            {
                user.UserMaterialTypes = _dbContext.UserMaterialTypes.Where(x => x.UserId == user.ID).ToList();
            }

            return users;
        }

        public List<User> GetUsersByMaterialType(string materialType)
        {
            var users = new List<User>();
            var acceptedMaterialType = _dbContext.MaterialTypes.Where(m => m.Name.Equals(materialType)).First();
            var userMaterialType = _dbContext.UserMaterialTypes.Where(um => um.MaterialTypeId == acceptedMaterialType.ID);

            foreach (var element in userMaterialType)
            {
                users.Add(_dbContext.Users.Where(x => x.ID == element.UserId).First());
            }
            return users;
        }
        public List<User> GetUserByType(string type)
        {
            var users = new List<User>();
            users = _dbContext.Users.ToList().Where(x => x.Type.ToString().Equals(type)).ToList();
            return users;
        }
    }
}
