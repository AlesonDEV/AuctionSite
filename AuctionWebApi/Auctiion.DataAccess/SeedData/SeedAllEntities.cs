using Auctiion.DataAccess.Data;
using Auctiion.DataAccess.Services;
using Auction.Domain.Abstractions;
using Auction.Domain.Dto;
using Auction.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auctiion.DataAccess.SeedData
{
    public class SeedAllEntities
    {
        private readonly DataContext _context;
        private readonly IUserRepository _userRepository;

        public SeedAllEntities(DataContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public void SeedDataContext()
        {
            //Add 24 regions of Ukraine to database
            if (!_context.Regions.Any())
            {
                var Regions = new List<Region>()
                {
                    new Region { Name = "Volyn" },
                    new Region { Name = "Zhytomyr" },
                    new Region { Name = "Lviv" },
                    new Region { Name = "Rivne" },
                    new Region { Name = "Ternopil" },
                    new Region { Name = "Khmelnytskyi" },
                    new Region { Name = "Chernivtsi" },
                    new Region { Name = "Ivano-Frankivsk" },
                    new Region { Name = "Zakarpattia" },
                    new Region { Name = "Vinnytsia" },
                    new Region { Name = "Kirovohrad" },
                    new Region { Name = "Kherson" },
                    new Region { Name = "Mykolaiv" },
                    new Region { Name = "Odessa" },
                    new Region { Name = "Poltava" },
                    new Region { Name = "Sumy" },
                    new Region { Name = "Kharkiv" },
                    new Region { Name = "Dnipropetrovsk" },
                    new Region { Name = "Zaporizhzhia" },
                    new Region { Name = "Donetsk" },
                    new Region { Name = "Luhansk" },
                    new Region { Name = "Kyiv" },
                    new Region { Name = "Cherkasy" },
                    new Region { Name = "Chernihiv" }
                };

                _context.AddRange(Regions);
            }


            //Add Contact Types
            if(!_context.ContactTypes.Any())
            {
                var ContactTypes = new List<ContactType>()
                {
                    new ContactType {Name = "Email"},
                    new ContactType {Name = "Phone"},
                };

                _context.AddRange(ContactTypes);
            }

            //Add Category Types
            if(!_context.Categories.Any())
            {
                var Categories = new List<Category>()
                {
                    new Category {Name = "Computer"},
                    new Category {Name = "Electronics"},
                    new Category {Name = "Clothing"},
                    new Category {Name = "Furniture"},
                    new Category {Name = "Books"},
                    new Category {Name = "Food"},
                    new Category {Name = "Toys"},
                    new Category {Name = "Sports"},
                    new Category {Name = "Music"},
                    new Category {Name = "Movies"},
                    new Category {Name = "Health"},
                    new Category {Name = "Education"},
                };

                _context.AddRange(Categories);
            }

            //Add Status Types
            if (!_context.Statuses.Any())
            {
                var Statuss = new List<Status>()
                {
                    new Status {Name = "New Condition"},
                    new Status {Name = "Used Condition"}
                };

                _context.AddRange(Statuss);
            }

            //Must to take region, so save to db
            _context.SaveChanges();

            //Add identity, person, personContact, customer tables
            _userRepository.RegisterAccount(new RegisterDto
            {
                FirstName = "Yulia",
                LastName = "Smoletska",
                Email = "yuliasmoletska@gmail.com",
                Region = "Volyn",
                Settlement = "Lutsk",
                Password = "Password123@",
                ConfirmPassword = "Password123@",
            });

            _userRepository.RegisterAccount(new RegisterDto
            {
                FirstName = "Anna",
                LastName = "Kovalenko",
                Email = "annakovalenko@example.com",
                Region = "Kharkiv",
                Settlement = "Kharkiv",
                Password = "Password123@",
                ConfirmPassword = "Password123@"
            });

            _userRepository.RegisterAccount(new RegisterDto
            {
                FirstName = "Oleksandr",
                LastName = "Ivanov",
                Email = "oleksandrivanov@example.com",
                Region = "Dnipropetrovsk",
                Settlement = "Dnipro",
                Password = "Password123@",
                ConfirmPassword = "Password123@"
            });

            _userRepository.RegisterAccount(new RegisterDto
            {
                FirstName = "Natalia",
                LastName = "Kuznetsova",
                Email = "nataliakuznetsova@example.com",
                Region = "Lviv",
                Settlement = "Lviv",
                Password = "Password123@",
                ConfirmPassword = "Password123@"
            });

            _userRepository.RegisterAccount(new RegisterDto
            {
                FirstName = "Andrii",
                LastName = "Petrov",
                Email = "andriipetrov@example.com",
                Region = "Zaporizhzhia",
                Settlement = "Zaporizhzhia",
                Password = "Password123@",
                ConfirmPassword = "Password123@"
            });

            _userRepository.RegisterAccount(new RegisterDto
            {
                FirstName = "Pavlo",
                LastName = "Yermolenko",
                Email = "pavloyermolenko@example.com",
                Region = "Cherkasy",
                Settlement = "Cherkasy",
                Password = "Password123@",
                ConfirmPassword = "Password123@"
            });

            //Must to take customer, so save to db
            _context.SaveChanges();

            //Create Auction
            //if (!_context.Auctions.Any())
            //{
            //    var customers = _context.Customers.ToList();

            //    var itemsDetails = new List<ItemDetails>();

            //    for (int i = 0; i < 6; i++)
            //    {
            //        Category randomCategory = _context.Categories
            //                                   .OrderBy(r => Guid.NewGuid())
            //                                   .First();
            //        Status randomStatus = _context.Statuses
            //                                    .OrderBy(s => Guid.NewGuid())
            //                                    .First();

            //        var itemDetail = new ItemDetails()
            //        {
            //            AuctionDetails = new AuctionDetails
            //            {
            //                Description = GenerateRandomDescription(),
            //                CurrentPrice = (new Random()).Next(10, 500),
            //                Customer = GetRandomItem<Customer>(customers),
            //                StartTime = DateTime.Now,
            //                StartingPrice = 0M,
            //            }
            //        };

            //        var auction = new Auction.Domain.Models.Auction
            //        {
            //            Title = GenerateRandomTitle(),
            //            Category = randomCategory,
            //            Status = randomStatus,
            //        };

            //        itemDetail.AuctionDetails.Auction = auction;

            //        itemsDetails.Add(itemDetail);
            //    }

            //    _context.AddRange(itemsDetails);
            //}
            //_context.SaveChanges();

            ////Create BidUser
            //if (!_context.AuctionUsers.Any())
            //{
            //    var customers = _context.Customers.ToList();

            //    foreach (var customer in customers)
            //    {
            //        customer.BidUser = new List<BidUser>()
            //        {
            //            new BidUser
            //            {
            //                Customer = customer,
            //                Bid = new Bid()
            //                {
            //                    BidDate = DateTime.Now,
            //                    BidAmount = (new Random()).Next(10, 500),
            //                }
            //            },
            //            new BidUser
            //            {
            //                Customer = customer,
            //                Bid = new Bid()
            //                {
            //                    BidDate = DateTime.Now,
            //                    BidAmount = (new Random()).Next(10, 500),
            //                }
            //            },
            //            new BidUser
            //            {
            //                Customer = customer,
            //                Bid = new Bid()
            //                {
            //                    BidDate = DateTime.Now,
            //                    BidAmount = (new Random()).Next(10, 500),
            //                }
            //            },
            //        };
            //    }

            //    _context.AddRange(customers);
            //}

            ////Must to take auction, so save to db
            //_context.SaveChanges();

            //if (!_context.AuctionUsers.Any())
            //{
            //    var customers = _context.Customers.ToList();
            //    var auctions = _context.Auctions.ToList();

            //    var auctionUser = new List<AuctionUser>();

            //    for (int i = 0; i < 6; i++)
            //    {
            //        auctionUser.Add(new AuctionUser()
            //        {
            //            Auction = GetItemAtIndex<Auction.Domain.Models.Auction>(auctions, i),
            //            Customer = GetItemAtIndex<Customer>(customers, i)
            //        });
            //    }
            //    _context.AddRange(auctionUser);
            //}

            //if (!_context.BidAuctions.Any())
            //{
            //    var bids = _context.Bids.ToList();
            //    var auctions = _context.Auctions.ToList();

            //    var bidAuction = new List<BidAuction>();

            //    foreach (var auction in auctions)
            //    {
            //        for (int i = 0; i < 3; i++)
            //        {
            //            bidAuction.Add(new BidAuction()
            //            {
            //                Auction = auction,
            //                Bid = GetRandomItem<Bid>(bids)
            //            });
            //        }
            //    }
            //    _context.AddRange(bidAuction);
            //}

            //_context.SaveChanges();
        }

        public static T GetItemAtIndex<T>(List<T> list, int index)
        {
            if (list == null || index < 0 || index >= list.Count)
                throw new ArgumentException("Invalid list or index.");

            return list[index];
        }

        public static T GetRandomItem<T>(List<T> list)
        {
            if (list == null || list.Count == 0)
                throw new ArgumentException("List cannot be null or empty.");

            Random random = new Random();
            int randomIndex = random.Next(list.Count);
            return list[randomIndex];
        }

        public static string GenerateRandomTitle()
        {
            string[] titles = {
            "Fix the bug",
            "Implement new feature",
            "Update documentation",
            "Optimize code",
            "Refactor the module"
            };

            Random random = new Random();
            return titles[random.Next(titles.Length)];
        }

        public static string GenerateRandomDescription()
        {
            string[] descriptions = {
            "This action involves fixing a bug in the software.",
            "This action requires implementing a new feature according to the specifications.",
            "This action involves updating the documentation for the software.",
            "This action aims to optimize the performance of the code.",
            "This action involves refactoring a specific module in the codebase."
            };

            Random random = new Random();
            return descriptions[random.Next(descriptions.Length)];
        }
    }
}
