using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Models;

namespace BuisinessLogicLayer.Models
{
   public class UserBLL
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string Neighbourhood { get; set; }
        public string Type { get; set; }
        public ICollection<UserMaterialType> UserMaterialTypes { get; set; }
    }
}
