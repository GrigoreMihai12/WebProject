using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public long IDUser { get; set; }
        public long IDCenter { get; set; }
        public string UserEmail { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
    }
}
