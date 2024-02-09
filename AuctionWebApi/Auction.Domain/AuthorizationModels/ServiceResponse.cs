using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.AutherizationModels
{
    //Responsec for Api (register, login)
    public class SreviceResponse
    {
        public record class GeneralResponse(bool Flag, int Code, string Message);

        public record class LoginResponse(bool Flag, int Code, string Token, string Message);
    }
}
