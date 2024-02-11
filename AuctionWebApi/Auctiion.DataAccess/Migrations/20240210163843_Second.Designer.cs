﻿// <auto-generated />
using System;
using Auctiion.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Auctiion.DataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240210163843_Second")]
    partial class Second
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Auction.Domain.Models.Auction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<int>("StatusId")
                        .HasColumnType("int")
                        .HasColumnName("status_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("StatusId");

                    b.ToTable("Auctions");
                });

            modelBuilder.Entity("Auction.Domain.Models.AuctionDetails", b =>
                {
                    b.Property<int>("AuctionId")
                        .HasColumnType("int")
                        .HasColumnName("auction_id");

                    b.Property<int?>("CurrentBuyerId")
                        .HasColumnType("int")
                        .HasColumnName("current_buyer_id");

                    b.Property<decimal>("CurrentPrice")
                        .HasColumnType("decimal(16, 2)")
                        .HasColumnName("current_price");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("description");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime")
                        .HasColumnName("end_time");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime")
                        .HasColumnName("start_time");

                    b.Property<decimal>("StartingPrice")
                        .HasColumnType("decimal(16, 2)")
                        .HasColumnName("starting_price");

                    b.HasKey("AuctionId");

                    b.HasIndex("CurrentBuyerId");

                    b.ToTable("Auction_Details");
                });

            modelBuilder.Entity("Auction.Domain.Models.AuctionUser", b =>
                {
                    b.Property<int>("AuctionId")
                        .HasColumnType("int")
                        .HasColumnName("auction_id");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("AuctionId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Auction_User");
                });

            modelBuilder.Entity("Auction.Domain.Models.Bid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("BidAmount")
                        .HasColumnType("decimal(16, 2)")
                        .HasColumnName("bid_amount");

                    b.Property<DateTime>("BidDate")
                        .HasColumnType("datetime")
                        .HasColumnName("bid_time");

                    b.HasKey("Id");

                    b.ToTable("Bids");
                });

            modelBuilder.Entity("Auction.Domain.Models.BidAuction", b =>
                {
                    b.Property<int>("BidId")
                        .HasColumnType("int")
                        .HasColumnName("bid_id");

                    b.Property<int>("AuctionId")
                        .HasColumnType("int")
                        .HasColumnName("auction_id");

                    b.HasKey("BidId", "AuctionId");

                    b.HasIndex("AuctionId");

                    b.ToTable("Bid_Auction");
                });

            modelBuilder.Entity("Auction.Domain.Models.BidUser", b =>
                {
                    b.Property<int>("BidId")
                        .HasColumnType("int")
                        .HasColumnName("bid_id");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("BidId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Bid_User");
                });

            modelBuilder.Entity("Auction.Domain.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Auction.Domain.Models.Condition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Conditions");
                });

            modelBuilder.Entity("Auction.Domain.Models.ContactType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Contact_Type");
                });

            modelBuilder.Entity("Auction.Domain.Models.Customer", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int")
                        .HasColumnName("person_id");

                    b.Property<int>("CountOfBids")
                        .HasColumnType("int")
                        .HasColumnName("count_of_bids");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("user_id");

                    b.HasKey("PersonId");

                    b.HasIndex("UserId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Auction.Domain.Models.ItemDetails", b =>
                {
                    b.Property<int>("AuctionDetailsId")
                        .HasColumnType("int")
                        .HasColumnName("auction_details_id");

                    b.Property<int>("ConditionId")
                        .HasColumnType("int")
                        .HasColumnName("condition_id");

                    b.HasKey("AuctionDetailsId");

                    b.HasIndex("ConditionId");

                    b.ToTable("Item_Details");
                });

            modelBuilder.Entity("Auction.Domain.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("last_name");

                    b.Property<int>("RegionId")
                        .HasColumnType("int")
                        .HasColumnName("region_id");

                    b.Property<string>("Settlement")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("settlement");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Auction.Domain.Models.PersonContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ContactTypeId")
                        .HasColumnType("int")
                        .HasColumnName("contact_type_id");

                    b.Property<string>("ContactValue")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("contact_value");

                    b.Property<int>("PersonId")
                        .HasColumnType("int")
                        .HasColumnName("person_id");

                    b.HasKey("Id");

                    b.HasIndex("ContactTypeId");

                    b.HasIndex("PersonId");

                    b.ToTable("Person_Contact");
                });

            modelBuilder.Entity("Auction.Domain.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BinaryData")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasColumnName("binary_data");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("file_path");

                    b.Property<int>("ItemId")
                        .HasColumnType("int")
                        .HasColumnName("item_id");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Auction.Domain.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("Auction.Domain.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Auction.Domain.Models.Auction", b =>
                {
                    b.HasOne("Auction.Domain.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Auction.Domain.Models.Status", "Status")
                        .WithMany("Auctions")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Auction.Domain.Models.AuctionDetails", b =>
                {
                    b.HasOne("Auction.Domain.Models.Auction", "Auction")
                        .WithMany()
                        .HasForeignKey("AuctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Auction.Domain.Models.Customer", "Customer")
                        .WithMany("AuctionDetails")
                        .HasForeignKey("CurrentBuyerId");

                    b.Navigation("Auction");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Auction.Domain.Models.AuctionUser", b =>
                {
                    b.HasOne("Auction.Domain.Models.Auction", "Auction")
                        .WithMany("AuctionUser")
                        .HasForeignKey("AuctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Auction.Domain.Models.Customer", "Customer")
                        .WithMany("AuctionUser")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auction");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Auction.Domain.Models.BidAuction", b =>
                {
                    b.HasOne("Auction.Domain.Models.Auction", "Auction")
                        .WithMany("BidAuction")
                        .HasForeignKey("AuctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Auction.Domain.Models.Bid", "Bid")
                        .WithMany("BidAuction")
                        .HasForeignKey("BidId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auction");

                    b.Navigation("Bid");
                });

            modelBuilder.Entity("Auction.Domain.Models.BidUser", b =>
                {
                    b.HasOne("Auction.Domain.Models.Bid", "Bid")
                        .WithMany("BidUser")
                        .HasForeignKey("BidId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Auction.Domain.Models.Customer", "Customer")
                        .WithMany("BidUser")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bid");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Auction.Domain.Models.Customer", b =>
                {
                    b.HasOne("Auction.Domain.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Person");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Auction.Domain.Models.ItemDetails", b =>
                {
                    b.HasOne("Auction.Domain.Models.AuctionDetails", "AuctionDetails")
                        .WithMany()
                        .HasForeignKey("AuctionDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Auction.Domain.Models.Condition", "Condition")
                        .WithMany("ItemDetails")
                        .HasForeignKey("ConditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuctionDetails");

                    b.Navigation("Condition");
                });

            modelBuilder.Entity("Auction.Domain.Models.Person", b =>
                {
                    b.HasOne("Auction.Domain.Models.Region", "Region")
                        .WithMany("Persons")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Auction.Domain.Models.PersonContact", b =>
                {
                    b.HasOne("Auction.Domain.Models.ContactType", "ContactType")
                        .WithMany("PersonContacts")
                        .HasForeignKey("ContactTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Auction.Domain.Models.Person", "Person")
                        .WithMany("PersonContact")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContactType");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Auction.Domain.Models.Photo", b =>
                {
                    b.HasOne("Auction.Domain.Models.ItemDetails", "ItemDetails")
                        .WithMany("Photos")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemDetails");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Auction.Domain.Models.Auction", b =>
                {
                    b.Navigation("AuctionUser");

                    b.Navigation("BidAuction");
                });

            modelBuilder.Entity("Auction.Domain.Models.Bid", b =>
                {
                    b.Navigation("BidAuction");

                    b.Navigation("BidUser");
                });

            modelBuilder.Entity("Auction.Domain.Models.Condition", b =>
                {
                    b.Navigation("ItemDetails");
                });

            modelBuilder.Entity("Auction.Domain.Models.ContactType", b =>
                {
                    b.Navigation("PersonContacts");
                });

            modelBuilder.Entity("Auction.Domain.Models.Customer", b =>
                {
                    b.Navigation("AuctionDetails");

                    b.Navigation("AuctionUser");

                    b.Navigation("BidUser");
                });

            modelBuilder.Entity("Auction.Domain.Models.ItemDetails", b =>
                {
                    b.Navigation("Photos");
                });

            modelBuilder.Entity("Auction.Domain.Models.Person", b =>
                {
                    b.Navigation("PersonContact");
                });

            modelBuilder.Entity("Auction.Domain.Models.Region", b =>
                {
                    b.Navigation("Persons");
                });

            modelBuilder.Entity("Auction.Domain.Models.Status", b =>
                {
                    b.Navigation("Auctions");
                });
#pragma warning restore 612, 618
        }
    }
}
