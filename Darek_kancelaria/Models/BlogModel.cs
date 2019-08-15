using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Darek_kancelaria.Models
{
    public class BlogModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [ScaffoldColumn(false)]
        [Display(Name = "Dodano")]
        public DateTime AddDate { get; set; }
        [Required]
        [Display(Name = "Tytuł")]
        [MinLength(10)]
        [MaxLength(1000)]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Treść")]
        [MinLength(1000)]
        [MaxLength(20000)]
        public string Content { get; set; }
    }
}