using Darek_kancelaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darek_kancelaria.Repository
{
    interface ICase : IRepository<CaseModel>
    {
        CaseModel GetCase(int id);
        IQueryable<CaseModel> GetAllCases();

    }
}
