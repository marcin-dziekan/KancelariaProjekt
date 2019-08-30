using Darek_kancelaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darek_kancelaria.Repository
{
    interface IPrice : IRepository<Price>
    {
        int? GetAllCasePrice(int id);
    }
}
