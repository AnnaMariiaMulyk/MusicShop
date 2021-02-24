namespace DAL2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 100),
                        MoneyBalance = c.Decimal(precision: 18, scale: 2),
                        AmountOfPurchases = c.Decimal(precision: 18, scale: 2),
                        AccountTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountTypes", t => t.AccountTypeId, cascadeDelete: true)
                .Index(t => t.AccountTypeId);
            
            CreateTable(
                "dbo.AccountTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        BandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bands", t => t.BandId)
                .Index(t => t.BandId);
            
            CreateTable(
                "dbo.Bands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Plates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        PublishingYear = c.Int(nullable: false),
                        CoastPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BandId = c.Int(nullable: false),
                        PublisherId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bands", t => t.BandId)
                .ForeignKey("dbo.Genres", t => t.GenreId)
                .ForeignKey("dbo.Publishers", t => t.PublisherId)
                .Index(t => t.BandId)
                .Index(t => t.PublisherId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tracks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        PlateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Plates", t => t.PlateId)
                .Index(t => t.PlateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tracks", "PlateId", "dbo.Plates");
            DropForeignKey("dbo.Plates", "PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.Plates", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Plates", "BandId", "dbo.Bands");
            DropForeignKey("dbo.Artists", "BandId", "dbo.Bands");
            DropForeignKey("dbo.Accounts", "AccountTypeId", "dbo.AccountTypes");
            DropIndex("dbo.Tracks", new[] { "PlateId" });
            DropIndex("dbo.Plates", new[] { "GenreId" });
            DropIndex("dbo.Plates", new[] { "PublisherId" });
            DropIndex("dbo.Plates", new[] { "BandId" });
            DropIndex("dbo.Artists", new[] { "BandId" });
            DropIndex("dbo.Accounts", new[] { "AccountTypeId" });
            DropTable("dbo.Tracks");
            DropTable("dbo.Publishers");
            DropTable("dbo.Genres");
            DropTable("dbo.Plates");
            DropTable("dbo.Bands");
            DropTable("dbo.Artists");
            DropTable("dbo.AccountTypes");
            DropTable("dbo.Accounts");
        }
    }
}
