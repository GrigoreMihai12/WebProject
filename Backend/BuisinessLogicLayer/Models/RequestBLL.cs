using System;
using System.Collections.Generic;
using System.Text;

namespace BuisinessLogicLayer.Models
{
    public class RequestBLL
    {
        public long ID { get; set; }
        public long IDUser { get; set; }
        public long IDCenter { get; set; }
        public string UserEmail { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
    }
}
