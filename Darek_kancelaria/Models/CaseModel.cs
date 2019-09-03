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
        public string Result { get; set; }
        public bool Status { get; set; }
        public DateTime AddDate { get; set; }
        public virtual ICollection<EvidenceModel> EvidenceModels { get; set; }
        public virtual ICollection<DocumentModel> DocumentsModels { get; set; }
        public virtual ICollection<Termcs> Terms { get; set; }
        public virtual ICollection<Price> Price { get; set; }

        public Dictionary<string, string> CaseType = new Dictionary<string, string>();
        public CaseModel()
        {
            CaseType.Add("C", "Cywilna - tryb dla wszczętych przed tym sądem na skutek pozwu lub skargi o uchylenie wyroku sądu polubownego spraw cywilnych rozpoznawanych w procesie");
            CaseType.Add("GC", "Gospodarcza - tryb dla wszczętych przed tym sądem spraw gospodarczych rozpoznawanych w procesie na skutek pozwu lub skargi o uchylenie wyroku sądu polubownego");
            CaseType.Add("GNs", "Gospodarcza - tryb nieprocesowy");
            CaseType.Add("GNc", "Gospodarcza - tryb postępowania nakazowy lub upominawczy");
            CaseType.Add("GNo", "Gospodarcza - tryb spraw rozpoznawanych według przepisów o procesie i o sądzie polubownym");
            CaseType.Add("GCps", "Gospodarcza - tryb w którym rejestruje się wnioski o udzielenie pomocy sądowej w sprawach gospodarczych");
            CaseType.Add("Ga", "Gospodarcza - tryb spraw gospodarczych przedstawionych z apelacjami od orzeczeń sądów rejonowych");
            CaseType.Add("Gz", "Gospodarcza - tryb spraw gospodarczych przedstawionych z zażaleniami na postanowienia rejonowych sądów rejonowych i zarządzenia wydane w postępowaniu przed tymi sądami");
            CaseType.Add("GU", "Gospodarcza - tryb spraw o ogłoszenie upadłości, dla spraw o wtórne postępowanie upadłościowe oraz o uznanie zagranicznego postępowania upadłościowego, a także o uchylenie i zmianę orzeczenia o uznaniu");
            CaseType.Add("GUp", "Gospodarcza - tryb spraw upadłościowych po ogłoszeniu upadłości, w tym dla wtórnych postępowań upadłościowych");
            CaseType.Add("GN", "Gospodarcza - tryb spraw z zakresu postępowania naprawczego");
            CaseType.Add("Gzd", "Gospodarcza - tryb spraw o zakaz prowadzenia działalności gospodarczej");
            CaseType.Add("GUu", "Gospodarcza - tryb spraw o zmianę i uchylenie układu zawartego w postępowaniu upadłościowym i naprawczym");
            CaseType.Add("Ns", "Cywilna - tryb spraw cywilnych rozpoznawanych w trybie postępowania nieprocesowego");
            CaseType.Add("Nc", "Cywilna - tryb spraw wszczętych przed tym sądem w postępowaniu nakazowym i upominawczym");
            CaseType.Add("Nc-e", "Cywilna - tryb spraw wszczętych w Elektronicznym Postępowaniu Upominawczym");
            CaseType.Add("Co", "Cywilna - dla innych spraw cywilnych rozpoznawanych według przepisów o procesie i o sądzie polubownym");
            CaseType.Add("CG-G", "Cywilna - tryb  dla spraw z zakresu prawa geologicznego i górniczego");
            CaseType.Add("Cps", "Cywilna - tryb w którym rejestruje się wnioski o udzielenie pomocy sądowej w sprawach cywilnych");
            CaseType.Add("Ca", "Cywilna - tryb dla spraw przedstawionych z apelacjami od orzeczeń sądów rejonowych");
            CaseType.Add("Cz", "Cywilna - tryb spraw przedstawionych z zażaleniami na postanowienia sądów rejonowych i zarządzenia wydane w postępowaniu przed tymi sądami");
            CaseType.Add("Cz-e", "Cywilna - tryb spraw przedstawionych z zażaleniami na postanowienia i zarządzenia wydane w Elektronicznym Postępowaniu Upominawczym");
            CaseType.Add("GR", "Upadłościowa i restrukturyzacyjna - tryb spraw o otwarcie postępowania restrukturyzacyjnego");
            CaseType.Add("GRz", "Upadłościowa i restrukturyzacyjna - tryb spraw restrukturyzacyjnych po wpłynięciu wniosku o zatwierdzenie układu w postępowaniu o zatwierdzenie układu");
            CaseType.Add("GRu", "Upadłościowa i restrukturyzacyjna - tryb spraw restrukturyzacyjnych po otwarciu postępowania układowego");
            CaseType.Add("GRs", "Upadłościowa i restrukturyzacyjna - tryb spraw restrukturyzacyjnych po otwarciu postępowania sanacyjnego");
            CaseType.Add("GRo", "Upadłościowa i restrukturyzacyjna - tryb dla wszczętych przed sądem restrukturyzacyjnym spraw rozpoznawanych według przepisów k.p.c., w tym spraw z wniosku Ministra Sprawiedliwości złożonego na podstawie art. 18a ust. 1 ustawy o licencji doradcy restrukturyzacyjnego");
            CaseType.Add("GUo", "Upadłościowa i restrukturyzacyjna - tryb dla wszczętych przed sądem upadłościowym spraw rozpoznawanych według przepisów k.p.c., w tym powództwa o wyłączenie z masy upadłości oraz spraw z wniosku Ministra Sprawiedliwości złożonego na podstawie art. 18a ust. 1 ustawy o licencji doradcy restrukturyzacyjnego");
        }

    }

    public class Cases
    {
        public CaseModel Case { get; set; }
        public PersonModel personelModel { get; set; }
        public List<CaseModel> CasesList { get; set; }
    }
}