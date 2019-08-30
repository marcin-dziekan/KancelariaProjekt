using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Darek_kancelaria.Models
{

    public class CaseModel 
    {
        
        public int Id { get; set; }
        [Required]
        [Display(Name ="Rodzaj sprawy")]
        public string Type { get; set; }
        [Required]
        [Display(Name = "Instancja")]
        public string Instance { get; set; }
        [Display(Name = "Sygnatura akt")]
        public string ActSignature { get; set; }
        [Required]
        [Display(Name ="Cena")]
        public string PriceAll { get; set; }
        public string UserId { get; set; }
        public bool Status { get; set; }
        public DateTime AddDate { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<EvidenceModel> EvidenceModels { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<DocumentModel> DocumentsModels { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<Termcs> Terms { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<Price> Price { get; set; }
    }

    public class Cases
    {
        public CaseModel Case { get; set; }
        public PersonModel personelModel { get; set; }
        public List<CaseModel> CasesList { get; set; }
    }
}