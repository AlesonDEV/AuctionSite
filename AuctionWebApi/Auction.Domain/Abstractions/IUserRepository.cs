using Auction.Domain.AutherizationModels;
using Auction.Domain.Dto;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Auction.Domain.AutherizationModels.SreviceResponse;

namespace Auction.Domain.Abstractions
{
    public interface IUserRepository
    {
        Task<GeneralResponse> RegisterAccount(RegisterDto registerDto);

        Task<LoginResponse> LoginAccount(LoginDto loginDTO);

        Task<bool> IsRegistred(string email);
    }
}
