using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Darek_kancelaria.Models
{
    public class PersonModel
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "Imie")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Nazwisko")]
        public string FName{ get; set; }
        [Required]
        [Display(Name = "Adres")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Kod pocztowy")]
        public string Zip { get; set; }
        [Display(Name = "Nr. telefonu")]
        [Phone]
        public string Phone { get; set; }
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        public DateTime AddDate { get; set; } 
        public string Role { get; set; }
    }
}