using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Models;

namespace BuisinessLogicLayer.Models
{
    public interface MaterialTypeBLL
    {
        
        public long ID { get; set; }
        public string Name { get; set; }
        public ICollection<UserMaterialType> UserMaterialTypes { get; set; }
    }
}
