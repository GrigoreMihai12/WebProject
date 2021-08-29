using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace RecycleAppBackend.Models
{
    public class MaterialTypeViewModel
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public ICollection<UserMaterialType> UserMaterialTypes { get; set; }
    }
}
