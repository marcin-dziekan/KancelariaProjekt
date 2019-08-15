using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Darek_kancelaria.Models
{
    public class ContactModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Adres")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Kod pocztowy")]
        [RegularExpression("[0-9]{2}-[0-9]{3}")]
        public string Code { get; set; }
        [Required]
        [Display(Name = "Poczta")]
        public string Postal { get; set; }
        [Required]
        [Display(Name = "Telefon")]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "Adres email")]
        [EmailAddress]
        public string Email { get; set; }
    }
}