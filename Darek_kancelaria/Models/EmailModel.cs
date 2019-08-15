using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Darek_kancelaria.Models
{
    public class EmailModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        [Display(Name = "Imię")]
        public string Name { get; set; }
        [EmailAddress]
        [Required]
        [Display(Name="E-mail")]
        public string Email { get; set; }

        [Required]
        [MinLength(10, ErrorMessage =  "Zapytanie nie może być krótsze niz 10 znaków")]
        [MaxLength(2000, ErrorMessage = "Zapytanie nie może być dłuższe niż 2000 znaków")]
        [Display(Name ="Treść zapytania")]
        public string Question { get; set; }

        [ScaffoldColumn(false)]
        public ContactModel Contact { get; set; }
    }
}