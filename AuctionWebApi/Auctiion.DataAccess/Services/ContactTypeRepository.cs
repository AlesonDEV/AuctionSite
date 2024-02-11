using Auctiion.DataAccess.Data;
using Auction.Domain.Abstractions;
using Auction.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auctiion.DataAccess.Services
{
    public class ContactTypeRepository : IContacTypeRepository
    {
        private readonly DataContext _context;

        public ContactTypeRepository(DataContext context)
        {
            _context = context;
        }

        public ContactType GetIdByNameOfContactType(string nameOfContactType)
        {
            var contactType = _context.ContactTypes.Where(n => n.Name == nameOfContactType).FirstOrDefault();
            return contactType;
        }
    }
}
