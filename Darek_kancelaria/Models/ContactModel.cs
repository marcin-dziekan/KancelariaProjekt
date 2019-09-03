using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Darek_kancelaria.Models
{
    public class ContactModel : PersonModel
    {
        [ScaffoldColumn(false)]
        new public int Id { get; set; }
    }
}