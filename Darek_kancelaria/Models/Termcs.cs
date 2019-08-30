using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Darek_kancelaria.Models
{
    public class Termcs
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nazwa wydarzenia")]
        public string Name { get; set; }
        [Required]
        [Display(Name="Termin wydarzenia")]
        public DateTime Term { get; set; }
        public virtual CaseModel CaseModel { get; set; }
    }
}