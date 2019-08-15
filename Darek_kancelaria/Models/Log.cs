using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Darek_kancelaria.Models
{
    public class Log
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateTime { get; set; }
        [Required]
        public string IpAddress { get; set; }
        [Required]
        public bool SMail { get; set; }
        [ScaffoldColumn(false)]
        public string EmailAddress { get; set; }
    }
}