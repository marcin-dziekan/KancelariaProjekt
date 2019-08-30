using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darek_kancelaria.Repository
{
    interface IRepository<T>
    {
        void Add(T element);
        void Dalete(T element);
        void SaveChanges();
    }
}
