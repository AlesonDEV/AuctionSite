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
    public class AuctionDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public int CategoryId { get; set; }

        public int StatusId { get; set; }
    }
}
