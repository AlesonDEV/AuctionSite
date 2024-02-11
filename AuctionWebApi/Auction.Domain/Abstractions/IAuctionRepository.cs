using Auction.Domain.Dto;
using Auction.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Abstractions
{
    public interface IAuctionRepository
    {
        Task<ICollection<AuctionPreviewDto>> GetPreviewInformation(int countOfAuctions);

        Task<int> GetCountOfBids(int auctionId);

        Task<ICollection<AuctionPreviewDto>> GetPreviewInformationSortedAscByBidSize(int countofAuctions);

        Task<ICollection<AuctionPreviewDto>> GetPreviewInformationSortedDescByBidSize(int countofAuctions);

        Task<ICollection<AuctionPreviewDto>> GetPreviewInformationByBidSize(decimal bidSize);

        Task<ICollection<AuctionPreviewDto>> GetPreviewInformationByParticipantCount(int bidCount);

        Task<ICollection<AuctionPreviewDto>> GetPreviewInformationByDate(DateTime dateTime);

        Task<ICollection<AuctionPreviewDto>> GetPreviewInformationByUser(string Email);

        Task<AuctionDetailDto> GetDetailInfo(int AuctionId);

        Task<bool> CreateAuction(Auction.Domain.Models.Auction auction);

        Task<bool> AuctionExists(int AuctionId);

        Task<Auction.Domain.Models.Auction> GetAuctionById(int AuctionId);

        Task<bool> DeleteAuction(Auction.Domain.Models.Auction auction);

        Task<bool> Save();

    }
}
