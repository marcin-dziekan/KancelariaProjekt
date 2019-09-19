using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Darek_kancelaria.Models
{
    public class ContactModel : PersonModel
    {
        new public int Id { get; set; }
        [Display(Name="NIP")]
        public string Nip { get; set; }
        [Display(Name ="REGON")]
        public string Regon { get; set; }
        [Display(Name ="Nr konta")]
        public string AccountNumber { get; set; }
    }
}