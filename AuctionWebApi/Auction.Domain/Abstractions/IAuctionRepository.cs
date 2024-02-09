using Auction.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Abstractions
{
    public interface IAuctionRepository
    {
        Task<ICollection<Auction.Domain.Models.Auction>> GetPreviewInformationOfAuctions(int countOfAuctions);

    }
}
