using Auctiion.DataAccess.Data;
using Auction.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auctiion.DataAccess.Services
{
    public class RegionRepository : IRegionRepository
    {
        private readonly DataContext _context;

        public RegionRepository(DataContext context)
        {
            _context = context;
        }

        //Used during registration
        public int GetRegionIdByName(string regionName)
        {
            var region = _context.Regions.Where(r => r.Name == regionName).FirstOrDefault();
            return region == null ? -1 : region.Id;
        }
    }
}
