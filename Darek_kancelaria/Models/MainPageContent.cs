
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Darek_kancelaria.Models
{
    public class PageContent
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        [MinLength(3)]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }
        [Required]
        [StringLength(10000)]
        [MinLength(20)]
        [Display(Name = "Treść")]
        public string Content { get; set; }
        [ScaffoldColumn(false)]
        public int WitchGrid { get; set; }
        [ScaffoldColumn(false)]
        public int PageNumber { get; set; }
    }


    public class MainPageContent
    {
        [Required]
        public PageContent FirsGrid { get; set; }
        [Required]
        public PageContent SecGrid { get; set; }
        [Required]
        public PageContent ThirdGrid { get; set; }
    }
}