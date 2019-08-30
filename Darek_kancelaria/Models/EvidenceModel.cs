using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Darek_kancelaria.Models
{
   

    public class DocumentModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Data { get; set; }
        public string Ext { get; set; }
        public string Added { get; set; }
        public virtual CaseModel CaseModel { get; set; }
    }
    public class EvidenceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Data { get; set; }
        public string Ext { get; set; }
        public string Added { get; set; }
        public virtual CaseModel CaseModel { get; set; }
    }
}