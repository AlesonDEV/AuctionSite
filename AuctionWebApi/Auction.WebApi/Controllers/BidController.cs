using Auctiion.DataAccess.Services;
using Auction.Domain.Abstractions;
using Auction.Domain.Dto;
using Auction.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Auction.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidController : ControllerBase
    {
        private readonly IBidRepository _bidRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAuctionRepository _auctionRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IBidUserRepository _bidUserRepository;
        private readonly IBidAuctionRepository _bidAuctionRepository;

        public BidController(IBidRepository bidRepository, 
            IUserRepository userRepository,
            IAuctionRepository auctionRepository,
            ICustomerRepository customerRepository,
            IBidUserRepository bidUserRepository,
            IBidAuctionRepository bidAuctionRepository)
        {
            _bidRepository = bidRepository;
            _userRepository = userRepository;
            _auctionRepository = auctionRepository;
            _customerRepository = customerRepository;
            _bidUserRepository = bidUserRepository;
            _bidAuctionRepository = bidAuctionRepository;
        }

        [HttpGet("{bidId}")]
        [ProducesResponseType(200, Type = typeof(ICollection<BidGetDto>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetBidsByAuction(int bidId)
        {
            var bidsAuction = await _bidRepository.GetBidsByAuction(bidId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(bidsAuction);
        }

        //Create Bid
        [HttpPost("createBid")]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateBid([FromQuery] string userEmail, [FromQuery] int auctionId, [FromBody] BidPostDto bidPostDto)
        {
            if (bidPostDto == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _userRepository.IsRegistred(userEmail))
                return BadRequest(ModelState);

            var bid = new Bid
            {
                BidAmount = bidPostDto.BidAmount,
                BidDate = DateTime.Now,
            };

            BidAuction bidAuction = new BidAuction()
            {
                Bid = bid,
                Auction = await _auctionRepository.GetAuctionById(auctionId),
            };

            BidUser bidUser = new BidUser()
            {
                Bid = bid,
                Customer = await _customerRepository.GetCustomerByEmail(userEmail),
            };

            if (!await _bidRepository.BidCreate(bid) ||
                !await _bidUserRepository.BidUserCreate(bidUser) ||
                !await _bidAuctionRepository.BidAuctionCreate(bidAuction))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully created");
        }

        [HttpDelete("deleteBid/{bidId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteBid(int bidId)
        {
            if (!await _bidRepository.BidExist(bidId))
            {
                ModelState.AddModelError("", "There are not such auction");
                return StatusCode(404, ModelState);
            }

            var bidToDelete = await _bidRepository.GetBidById(bidId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _bidRepository.BidDelete(bidToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting!");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
