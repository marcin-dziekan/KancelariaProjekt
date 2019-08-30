using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Darek_kancelaria.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Darek_kancelaria.Repository
{
    public class PersonRepo : IPersonRepository
    {

        private ApplicationDbContext _context;
        private RoleManager<IdentityRole> _rm;
        public PersonRepo()
        {
            _context = new ApplicationDbContext();
            _rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
        }

        public IQueryable<PersonModel> GetAllUsers()
        {
            return _context.Users.Select(x => new PersonModel { Id = x.Id, Name = x.Name, FName = x.FName, AddDate = x.AddDate, Address = x.Address, Email = x.Email, Phone = x.PhoneNumber, Zip = x.Zip });
        }

        public IQueryable<PersonModel> GetAllUsersByRole(string roleName)
        {
            var roleId = _rm.FindByName(roleName);
            return _context.Users.Where(x => x.Roles.Any(z => z.RoleId == roleId.Id)).Select(x => new PersonModel { Id = x.Id, Name = x.Name, FName = x.FName, AddDate = x.AddDate, Address = x.Address, Email = x.Email, Phone = x.PhoneNumber, Zip = x.Zip, Role = roleName });
        }

        public PersonModel GetUserById(string id)
        {
            return _context.Users.Where(x => x.Id == id).Select(x => new PersonModel { Name = x.Name, FName = x.FName, Address = x.Address, Email = x.Email, Phone = x.PhoneNumber, Zip = x.Zip, Id = x.Id, AddDate = x.AddDate }).FirstOrDefault();
        }

        public List<PersonModel> GetUsersByRoleAndName(string name, string roleName)
        {
            var roleId = _rm.FindByName(roleName);
            return _context.Users.Where(x => x.Roles.Any(z => z.RoleId == roleId.Id) && x.Name.Contains(name) || x.Roles.Any(z => z.RoleId == roleId.Id) && x.FName.Contains(name)).Select(x => new PersonModel { Name = x.Name, FName = x.FName, Address = x.Address, Email = x.Email, Phone = x.PhoneNumber, Zip = x.Zip, Id = x.Id, AddDate = x.AddDate }).ToList();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}