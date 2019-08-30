using Darek_kancelaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darek_kancelaria.Repository
{
    interface IPersonRepository
    {
        IQueryable<PersonModel> GetAllUsersByRole(string type);
        IQueryable<PersonModel> GetAllUsers();
        List<PersonModel> GetUsersByRoleAndName(string name, string roleName);
        PersonModel GetUserById(string id);
        void SaveChanges();

    }
}
