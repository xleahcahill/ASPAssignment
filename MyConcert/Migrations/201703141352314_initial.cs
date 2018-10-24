namespace MyConcert.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artist",
                c => new
                    {
                        ArtistID = c.String(nullable: false, maxLength: 128),
                        ArtistName = c.String(nullable: false, maxLength: 30),
                        Genre = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.ArtistID);
            
            CreateTable(
                "dbo.Booking",
                c => new
                    {
                        BookingNo = c.Int(nullable: false, identity: true),
                        CustomerId = c.String(nullable: false),
                        Email = c.String(maxLength: 100),
                        PurchaseDate = c.DateTime(nullable: false),
                        BillingAddress = c.String(maxLength: 50),
                        BillingCity = c.String(maxLength: 30),
                        BillingPostcode = c.String(maxLength: 8),
                        PaymentDetails = c.String(nullable: false, maxLength: 50),
                        Show_ShowId = c.Int(),
                    })
                .PrimaryKey(t => t.BookingNo)
                .ForeignKey("dbo.Show", t => t.Show_ShowId)
                .Index(t => t.Show_ShowId);
            
            CreateTable(
                "dbo.BookingTicket",
                c => new
                    {
                        BookingNo = c.Int(nullable: false),
                        TicketId = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookingNo, t.TicketId })
                .ForeignKey("dbo.Booking", t => t.BookingNo, cascadeDelete: true)
                .ForeignKey("dbo.TicketDetails", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.BookingNo)
                .Index(t => t.TicketId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        Surname = c.String(nullable: false, maxLength: 30),
                        DOB = c.DateTime(nullable: false),
                        Address = c.String(nullable: false, maxLength: 50),
                        City = c.String(nullable: false, maxLength: 20),
                        Postcode = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.AspNetUsers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        Created = c.DateTime(nullable: false),
                        LastLogin = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.TicketDetails",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        VIPTicketExtraPrice = c.Double(nullable: false),
                        TieredSeatingExtraTicketPrice = c.Double(nullable: false),
                        StandardTicketPrice = c.Double(nullable: false),
                        FrontRowSeatingExtraPrice = c.Double(nullable: false),
                        name = c.String(),
                        TicketDescription = c.String(maxLength: 30),
                        ShowId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TicketId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.ShowDetails",
                c => new
                    {
                        ShowDetailsId = c.Int(nullable: false, identity: true),
                        Genre = c.String(nullable: false, maxLength: 30),
                        VenueName = c.String(nullable: false, maxLength: 30),
                        VenueId = c.String(nullable: false),
                        ShowDate = c.DateTime(nullable: false),
                        ShowStartTime = c.DateTime(nullable: false),
                        ShowEndTime = c.DateTime(nullable: false),
                        Summary = c.String(nullable: false, maxLength: 1000),
                        Duration = c.Time(nullable: false, precision: 7),
                        IsVIPAvailable = c.Boolean(nullable: false),
                        IsFrontRowAvailable = c.Boolean(nullable: false),
                        IsTieredSeatingAvailable = c.Boolean(nullable: false),
                        ArtistName = c.String(),
                    })
                .PrimaryKey(t => t.ShowDetailsId);
            
            CreateTable(
                "dbo.Show",
                c => new
                    {
                        ShowId = c.Int(nullable: false, identity: true),
                        ShowDate = c.DateTime(nullable: false),
                        VenueId = c.String(nullable: false, maxLength: 128),
                        ShowTitle = c.String(nullable: false, maxLength: 20),
                        ArtistId = c.String(nullable: false, maxLength: 20),
                        ArtistName = c.String(nullable: false, maxLength: 20),
                        SeatingTypes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShowId)
                .ForeignKey("dbo.Venue", t => t.VenueId, cascadeDelete: true)
                .Index(t => t.VenueId);
            
            CreateTable(
                "dbo.Venue",
                c => new
                    {
                        VenueId = c.String(nullable: false, maxLength: 128),
                        VenueName = c.String(nullable: false, maxLength: 30),
                        City = c.String(nullable: false, maxLength: 30),
                        Capacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VenueId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Show", "VenueId", "dbo.Venue");
            DropForeignKey("dbo.Booking", "Show_ShowId", "dbo.Show");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.BookingTicket", "TicketId", "dbo.TicketDetails");
            DropForeignKey("dbo.Customer", "CustomerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BookingTicket", "BookingNo", "dbo.Booking");
            DropIndex("dbo.Show", new[] { "VenueId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Customer", new[] { "CustomerId" });
            DropIndex("dbo.BookingTicket", new[] { "TicketId" });
            DropIndex("dbo.BookingTicket", new[] { "BookingNo" });
            DropIndex("dbo.Booking", new[] { "Show_ShowId" });
            DropTable("dbo.Venue");
            DropTable("dbo.Show");
            DropTable("dbo.ShowDetails");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TicketDetails");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Customer");
            DropTable("dbo.BookingTicket");
            DropTable("dbo.Booking");
            DropTable("dbo.Artist");
        }
    }
}
