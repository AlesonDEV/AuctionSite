using Auctiion.DataAccess.Data;
using Auctiion.DataAccess.SeedData;
using Auction.Domain.Abstractions;
using Auction.Domain.Dto;
using Auction.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auctiion.DataAccess.Services
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly DataContext _context;
        private readonly int _countOfElementsOfPage = 9;

        public AuctionRepository(DataContext context)
        {
            _context = context;
        }

        //Get count of bids if certain auction
        public async Task<int> GetCountOfBids(int auctionId)
        {
            int count = await _context.Auctions.CountAsync(a => a.Id == auctionId);
            return count;
        }

        //Getting preview information about auctions
        public async Task<ICollection<AuctionPreviewDto>> GetPreviewInformation(int countOfAuctions)
        {
            var auctions = await _context.Auctions.Take(countOfAuctions)
                                            .Join(_context.AuctionDetails,
                                            auction => auction.Id,
                                            auctionDetail => auctionDetail.AuctionId,
                                            (auction, auctionDetail) => new AuctionPreviewDto
                                            {
                                                AuctionId = auction.Id,
                                                Title = auction.Title,
                                                CurrentBid = auctionDetail.CurrentPrice,
                                                StartTime = auctionDetail.StartTime,
                                                EndTime = auctionDetail.EndTime,
                                            })
                                            .ToListAsync();

            foreach (var auction in auctions)
                auction.CurrentNumberOfBid = await GetCountOfBids(auction.AuctionId);

            return auctions;
        }

        //For filtering data: sorting by date ASC
        public async Task<ICollection<AuctionPreviewDto>> GetPreviewInformationSortedAscByBidSize(int countofAuctions)
        {
            var auctions = await GetPreviewInformation(countofAuctions);

            return auctions.OrderBy(a => a.CurrentBid).ToList();
        }

        //For filtering data: sorting by date DESC
        public async Task<ICollection<AuctionPreviewDto>> GetPreviewInformationSortedDescByBidSize(int countofAuctions)
        {
            var auctions = await GetPreviewInformation(countofAuctions);

            return auctions.OrderByDescending(a => a.CurrentBid).ToList();
        }

        //For filtering data: sorting by bid size
        public async Task<ICollection<AuctionPreviewDto>> GetPreviewInformationByBidSize(decimal bidSize)
        {
            var auctions = await _context.Auctions
                                            .Join(_context.AuctionDetails,
                                            auction => auction.Id,
                                            auctionDetail => auctionDetail.AuctionId,
                                            (auction, auctionDetail) => new AuctionPreviewDto
                                            {
                                                AuctionId = auction.Id,
                                                Title = auction.Title,
                                                CurrentBid = auctionDetail.CurrentPrice,
                                                StartTime = auctionDetail.StartTime,
                                                EndTime = auctionDetail.EndTime,
                                            })
                                            .Where(a => a.CurrentBid < bidSize)
                                            .OrderByDescending(a => a.CurrentBid)
                                            .Take(_countOfElementsOfPage)
                                            .ToListAsync();

            return auctions;
        }

        //For filtering data: sorting by bid count
        public async Task<ICollection<AuctionPreviewDto>> GetPreviewInformationByParticipantCount(int bidCount)
        {
            var auctions = await _context.AuctionUsers
                                .GroupBy(a => a.AuctionId) 
                                .Select(a => new
                                {
                                    auctionId = a.Key,
                                    UserCount = a.Count()
                                })
                                .Where(c => c.UserCount < bidCount)
                                .Join(_context.Auctions,
                                ba => ba.auctionId,
                                a => a.Id,
                                (ba, a) => new 
                                {
                                     AuctionId = ba.auctionId,
                                     Title = a.Title,
                                     UserCount = ba.UserCount
                                })
                                .Join(_context.AuctionDetails,
                                ba => ba.AuctionId,
                                ad => ad.AuctionId,
                                (ba, ad) => new AuctionPreviewDto
                                {
                                    AuctionId = ba.AuctionId,
                                    Title = ba.Title,
                                    StartTime = ad.StartTime,
                                    EndTime = ad.EndTime,
                                    CurrentBid = ad.CurrentPrice,
                                    CurrentNumberOfBid = ba.UserCount,
                                })
                                .ToListAsync();

            return auctions;
        }

        //For filtering data: filtering by date
        public async Task<ICollection<AuctionPreviewDto>> GetPreviewInformationByDate(DateTime dateTime)
        {
            var auctions = await _context.AuctionDetails
                                            .Where(ad => ad.StartTime == dateTime)
                                            .Join(_context.Auctions,
                                            ad => ad.AuctionId,
                                            a => a.Id,
                                            (ad, a) => new AuctionPreviewDto
                                            {
                                                AuctionId = a.Id,
                                                Title = a.Title,
                                                CurrentBid = ad.CurrentPrice,
                                                StartTime = ad.StartTime,
                                                EndTime = ad.EndTime,
                                            })
                                            .ToListAsync();

            foreach (var auction in auctions)
                auction.CurrentNumberOfBid = await GetCountOfBids(auction.AuctionId);

            return auctions;
        }

        //Get detail information about auction
        public async Task<AuctionDetailDto> GetDetailInfo(int AuctionId)
        {
            var auction = await _context.Auctions
                                            .Join(_context.AuctionDetails,
                                            auction => auction.Id,
                                            auctionDetail => auctionDetail.AuctionId,
                                            (auction, auctionDetail) => new AuctionDetailDto
                                            {
                                                Id = auction.Id,
                                                Title = auction.Title,
                                                CurrentBid = auctionDetail.CurrentPrice,
                                                Date = auctionDetail.StartTime,
                                                Description = auctionDetail.Description,
                                            })
                                            .Where(a => a.Id == AuctionId)
                                            .FirstOrDefaultAsync();

            if (auction == null)
                return null;

            auction.CountOfParticipants = await GetCountOfBids(AuctionId);

            return auction;
        }

        public async Task<ICollection<AuctionPreviewDto>> GetPreviewInformationByUser(string Email)
        {
            var auctions = await _context.Customers
                                        .Join(_context.Users,
                                        c => c.UserId,
                                        u => u.Id,
                                        (c, u) => new
                                        {
                                            Email = u.Email,
                                            CustomerId = c.PersonId
                                        })
                                        .Join(_context.AuctionUsers,
                                        c => c.CustomerId,
                                        au => au.UserId,
                                        (c, au) => new
                                        {
                                            c.Email,
                                            c.CustomerId,
                                            AuctionId = au.AuctionId
                                        })
                                        .Join(_context.Auctions,
                                        au => au.AuctionId,
                                        a => a.Id,
                                        (au, a) => new 
                                        {
                                            au.Email,
                                            au.CustomerId,
                                            AuctionId = au.AuctionId,
                                            Title = a.Title,
                                        })
                                        .Join(_context.AuctionDetails,
                                        a => a.AuctionId,
                                        ad => ad.AuctionId,
                                        (a, ad) => new AuctionPreviewDto
                                        { 
                                            AuctionId = a.AuctionId,
                                            CurrentBid = ad.CurrentPrice,
                                            EndTime = ad.EndTime,
                                            StartTime = ad.StartTime,
                                            Title = a.Title,
                                        }).ToListAsync();

            foreach (var auction in auctions)
                auction.CurrentNumberOfBid = await GetCountOfBids(auction.AuctionId);

            return auctions;
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> CreateAuction(Auction.Domain.Models.Auction auction)
        {
            await _context.Auctions.AddAsync(auction);
            return await Save();
        }



        public async Task<bool> DeleteAuction(Auction.Domain.Models.Auction auction)
        {
            _context.Auctions.Remove(auction);
            return await Save();
        }

        public async Task<bool> AuctionExists(int AuctionId)
        {
            return await _context.Auctions.Where(p => p.Id == AuctionId).AsNoTracking().FirstOrDefaultAsync() != null ? true : false;
        }

        public async Task<Auction.Domain.Models.Auction> GetAuctionById(int AuctionId)
        {
            return await _context.Auctions.Where(a => a.Id == AuctionId).FirstOrDefaultAsync();
        }
    }
}
