using Auction.Domain.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Auction.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private readonly IAuctionRepository _auctionRepository;

        public AuctionController(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }

        //[HttpGet("previewInfo/{countOfItems")]
        //public async Task<IActionResult> GetPreviewOfAuctions(int countOfAuctions)
        //{
        //    var 
        //}
    }
}
