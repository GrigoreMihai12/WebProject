using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    public class User
    {
        public enum UserType
        {
            RECYCLING_USER,
            RECYCLING_CENTER
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string Neighbourhood { get; set; }
        public UserType Type { get; set; }
        public ICollection<UserMaterialType> UserMaterialTypes { get; set; }
    }
}
