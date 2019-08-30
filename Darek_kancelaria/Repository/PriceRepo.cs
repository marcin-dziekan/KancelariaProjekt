using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Darek_kancelaria.Models;

namespace Darek_kancelaria.Repository
{
    public class PriceRepo : IPrice
    {
        ApplicationDbContext _context;

        public PriceRepo()
        {
            _context = new ApplicationDbContext();
        }
        public void Add(Price element)
        {
            _context.Prices.Add(element);
        }

        public void Dalete(Price element)
        {
            _context.Prices.Remove(element);
        }

        public int? GetAllCasePrice(int caseId)
        {
            return _context.Prices.Where(x => x.CaseModel.Id == caseId).Sum(x => x.Cash);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}