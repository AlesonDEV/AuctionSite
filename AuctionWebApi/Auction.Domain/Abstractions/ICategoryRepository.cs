using Auction.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Abstractions
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetAllCategories();
        Category GetCategory(int categoryId);
        Category GetCategoryByAuction(int auctionId);
        bool CategoryExists(int categoryId);
        bool Save();
    }
}
