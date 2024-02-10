using Auction.Domain.Dto;
using Auction.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Services.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Auction.Domain.Models.Auction, AuctionDto>();
            CreateMap<Category, CategoryDto>();
        }
    }
}
