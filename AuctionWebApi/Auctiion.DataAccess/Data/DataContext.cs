using Auction.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auctiion.DataAccess.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        //Tables set
        public DbSet<Auction.Domain.Models.Auction> Auctions { get; set; }

        public DbSet<AuctionDetails> AuctionDetails { get; set; }

        public DbSet<AuctionUser> AuctionUsers { get; set; }

        public DbSet<Bid> Bids { get; set; }

        public DbSet<BidAuction> BidAuctions { get; set; }

        public DbSet<BidUser> BidUsers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Condition> Conditions { get; set; }

        public DbSet<ContactType> ContactTypes { get; set; }

        public DbSet<ItemDetails> ItemDetails { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<PersonContact> PersonContacts { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<User> Users { get; set; }

        //Fluent Api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Setup the many to many relationships
            //Many with many: AuctionUser
            modelBuilder.Entity<AuctionUser>()
                            .HasKey(au => new { au.AuctionId, au.UserId });

            modelBuilder.Entity<AuctionUser>()
                           .HasOne( a => a.Auction)
                           .WithMany(au => au.AuctionUser)
                           .HasForeignKey(a => a.AuctionId);

            modelBuilder.Entity<AuctionUser>()
                           .HasOne( u => u.User)
                           .WithMany(au => au.AuctionUser)
                           .HasForeignKey(u => u.UserId);

            //Many with many: BidAuction
            modelBuilder.Entity<BidAuction>()
                           .HasKey(ba => new { ba.BidId, ba.AuctionId });

            modelBuilder.Entity<BidAuction>()
                           .HasOne(b => b.Bid)
                           .WithMany(ba => ba.BidAuction)
                           .HasForeignKey(b => b.BidId);

            modelBuilder.Entity<BidAuction>()
                           .HasOne(a => a.Auction)
                           .WithMany(ba => ba.BidAuction)
                           .HasForeignKey(a => a.AuctionId);

            //Many with many: BidUser
            modelBuilder.Entity<BidUser>()
                           .HasKey(bu => new { bu.BidId, bu.UserId });

            modelBuilder.Entity<BidUser>()
                           .HasOne(b => b.Bid)
                           .WithMany(bu => bu.BidUser)
                           .HasForeignKey(u => u.BidId);

            modelBuilder.Entity<BidUser>()
                           .HasOne(u => u.User)
                           .WithMany(bu => bu.BidUser)
                           .HasForeignKey(u => u.UserId);
        }
    }
}
