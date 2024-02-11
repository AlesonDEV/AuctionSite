using Auction.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Dto
{
    public class AuctionPreviewDto
    {

        public int AuctionId { get; set; }

        public string Title { get; set; } = null!;

        public decimal CurrentBid { get; set; }

        public int CurrentNumberOfBid { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        //Photo must be here
    }
}
