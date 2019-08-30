using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Darek_kancelaria.Models;

namespace Darek_kancelaria.Repository
{
    public class CaseRepo : ICase
    {
        private ApplicationDbContext _context;

        public CaseRepo()
        {
            _context = new ApplicationDbContext();
        }
        public void Add(CaseModel element)
        {
            _context.Cases.Add(element);
        }

        public void Dalete(CaseModel element)
        {
            _context.Cases.Remove(element);
        }

        public IQueryable<CaseModel> GetAllCases()
        {
            return _context.Cases.Select(x => x);
        }

        public CaseModel GetCase(int id)
        {
            return _context.Cases.Where(x => x.Id == id).Select(x => x).FirstOrDefault();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}