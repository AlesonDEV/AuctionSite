using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.AutherizationModels
{
    //For login system
    public record class UserSession(string? Id, string? Email, string? Role);
}
