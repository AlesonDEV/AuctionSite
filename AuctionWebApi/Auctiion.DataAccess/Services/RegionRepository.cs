using Auctiion.DataAccess.Data;
using Auction.Domain.Abstractions;
using Auction.Domain.Models;
using Microsoft.EntityFrameworkCore;
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
        public Region GetRegionIdByName(string regionName)
        {
            var region = _context.Regions.Where(r => r.Name == regionName).FirstOrDefault();
            return region;
        }

        public async Task<string> GetRegions()
        {
            var regions = await _context.Regions.ToListAsync();
            string stringRegions = "";

            int i = 0;

            foreach (var region in regions)
            {
                if (i == 0)
                {
                    stringRegions += (region.Name);
                    i++;
                    continue;
                }
                stringRegions += (',' + region.Name);
            }
            return stringRegions;
        }
    }
}
