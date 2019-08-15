using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Darek_kancelaria.Models
{
    public class FaceCountModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [DefaultValue(0)]
        public int Counter { get; set; }
    }
}