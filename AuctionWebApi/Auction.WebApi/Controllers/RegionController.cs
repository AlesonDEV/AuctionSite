using Auction.Domain.Abstractions;
using Auction.Domain.Dto;
using Auction.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Auction.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;

        public RegionController(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Region>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetRegions()
        {
            var regions = await _regionRepository.GetRegions();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(regions);
        }
    }
}
