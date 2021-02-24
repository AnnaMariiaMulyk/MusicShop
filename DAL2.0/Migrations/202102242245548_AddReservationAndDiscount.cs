namespace DAL2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReservationAndDiscount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                        DiscountAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        PlateId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Plates", t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Id)
                .Index(t => t.Id);
            
            AddColumn("dbo.Accounts", "ReservationId", c => c.Int(nullable: false));
            AddColumn("dbo.Plates", "ReservationId", c => c.Int());
            AddColumn("dbo.Genres", "DiscountId", c => c.Int());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "Id", "dbo.Accounts");
            DropForeignKey("dbo.Reservations", "Id", "dbo.Plates");
            DropForeignKey("dbo.Discounts", "Id", "dbo.Genres");
            DropIndex("dbo.Reservations", new[] { "Id" });
            DropIndex("dbo.Discounts", new[] { "Id" });
            DropColumn("dbo.Genres", "DiscountId");
            DropColumn("dbo.Plates", "ReservationId");
            DropColumn("dbo.Accounts", "ReservationId");
            DropTable("dbo.Reservations");
            DropTable("dbo.Discounts");
        }
    }
}
