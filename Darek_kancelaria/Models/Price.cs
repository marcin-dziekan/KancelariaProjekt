using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Darek_kancelaria.Models
{
    public class Price
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public int? Cash { get; set; }
        public bool Status { get; set; }
        public virtual CaseModel CaseModel { get; set; }
    }
}