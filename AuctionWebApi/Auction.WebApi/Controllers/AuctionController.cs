using Auction.Domain.Abstractions;
using Auction.Domain.Dto;
using Auction.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Auction.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IAuctionDetailsRepository _auctionDetailsRepository;
        private readonly IItemDetailsRepository _itemDetailsRepository;
        private readonly IAuctionUserRepository _auctionUserRepository;

        public AuctionController(IAuctionRepository auctionRepository,
            ICustomerRepository customerRepository,
            IAuctionDetailsRepository auctionDetailsRepository,
            IItemDetailsRepository itemDetailsRepository,
            IAuctionUserRepository auctionUserRepository)
        {
            _auctionRepository = auctionRepository;
            _customerRepository = customerRepository;
            _auctionDetailsRepository = auctionDetailsRepository;
            _itemDetailsRepository = itemDetailsRepository;
            _auctionUserRepository = auctionUserRepository;
        }

        [HttpGet("previewInfo/{countOfAuctions}")]
        [ProducesResponseType(200, Type = typeof(ICollection<AuctionPreviewDto>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetPreviewOfAuctions(int countOfAuctions)
        {
            var auctionPreviews = await _auctionRepository.GetPreviewInformation(countOfAuctions);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(auctionPreviews);
        }

        //Filtering data
        [HttpGet("sortedPreviewInfo/asc/{countOfAuctions}")]
        [ProducesResponseType(200, Type = typeof(ICollection<AuctionPreviewDto>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetSortedAscByDatePreviewOfAuctions(int countOfAuctions)
        {
            var auctionPreviews = await _auctionRepository.GetPreviewInformationSortedAscByBidSize(countOfAuctions);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(auctionPreviews);
        }

        //Filtering data
        [HttpGet("sortedPreviewInfo/desc/{countOfAuctions}")]
        [ProducesResponseType(200, Type = typeof(ICollection<AuctionPreviewDto>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetSortedDescByDatePreviewOfAuctions(int countOfAuctions)
        {
            var auctionPreviews = await _auctionRepository.GetPreviewInformationSortedDescByBidSize(countOfAuctions);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(auctionPreviews);
        }

        //Filtering data
        [HttpGet("previewInfoWithBid/{bidSize}")]
        [ProducesResponseType(200, Type = typeof(ICollection<AuctionPreviewDto>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetPreviewInfoWithBid(decimal bidSize)
        {
            var auctionPreviews = await _auctionRepository.GetPreviewInformationByBidSize(bidSize);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(auctionPreviews);
        }

        //Filtering data
        [HttpGet("previewWithCount/{participantCount}")]
        [ProducesResponseType(200, Type = typeof(ICollection<AuctionPreviewDto>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetPreviewInfoWithCount(int participantCount)
        {
            var auctionPreviews = await _auctionRepository.GetPreviewInformationByParticipantCount(participantCount);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(auctionPreviews);
        }

        //Filtering data
        [HttpGet("previewWithDate/{date}")]
        [ProducesResponseType(200, Type = typeof(ICollection<AuctionPreviewDto>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetPreviewInfoWithDate(DateTime date)
        {
            var auctionPreviews = await _auctionRepository.GetPreviewInformationByDate(date);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(auctionPreviews);
        }

        //Detail information
        [HttpGet("detailInfo/{auctionId}")]
        [ProducesResponseType(200, Type = typeof(AuctionDetailDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetDetailInfo(int auctionId)
        {
            var auctionPreviews = await _auctionRepository.GetDetailInfo(auctionId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(auctionPreviews);
        }

        //Preview information by user
        [HttpGet("previewInfoByUser/{email}")]
        [ProducesResponseType(200, Type = typeof(AuctionDetailDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetPreviewByEmail(string email)
        {
            var auctionPreviews = await _auctionRepository.GetPreviewInformationByUser(email);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(auctionPreviews);
        }

        //Create Auction
        [HttpPost("createAuction")]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateAuction([FromQuery] string userEmail, [FromBody] AuctionCreateDto auction)
        {
            if (auction == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Auction.Domain.Models.Auction createAuction = new Auction.Domain.Models.Auction
            {
                CategoryId = auction.CategoryId,
                StatusId = auction.StatusId,
                Title = auction.Title,
            };

            AuctionDetails auctionDetails = new AuctionDetails
            {
                Description = auction.Description,
                CurrentPrice = 0,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now,
                StartingPrice = 0,
                Auction = createAuction
            };

            ItemDetails itemDetails = new ItemDetails
            {
                ConditionId = auction.ConditionId,
                AuctionDetails = auctionDetails,
            };

            var customer = await _customerRepository.GetCustomerByEmail(userEmail);

            if (customer == null)
                return BadRequest(ModelState);

            AuctionUser auctionUser = new AuctionUser
            {
                Auction = createAuction,
                Customer = customer,
            };

            if (!await _auctionRepository.CreateAuction(createAuction) ||
                !await _auctionDetailsRepository.CreateAuctionDetails(auctionDetails) ||
                !await _itemDetailsRepository.CreateItemdetails(itemDetails) ||
                !await _auctionUserRepository.CreateAuctionUser(auctionUser))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully created");
        }

        //Delete Auction
        [HttpDelete("deleteAuction/{AuctionId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteAuction(int AuctionId)
        {
            if (!await _auctionRepository.AuctionExists(AuctionId))
            {
                ModelState.AddModelError("", "There are not such auction");
                return StatusCode(404, ModelState);
            }

            var auctionToDelete = await _auctionRepository.GetAuctionById(AuctionId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _auctionRepository.DeleteAuction(auctionToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting!");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
