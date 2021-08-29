using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleAppBackend.Models
{
    public class RequestViewModel
    {
        public long ID { get; set; }
        public string UserEmail { get; set; }
        public long IDCenter { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
        public string CenterName { get; set; }
    }
}
