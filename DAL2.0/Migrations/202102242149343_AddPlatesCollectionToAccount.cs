namespace DAL2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPlatesCollectionToAccount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plates", "Account_Id", c => c.Int());
            CreateIndex("dbo.Plates", "Account_Id");
            AddForeignKey("dbo.Plates", "Account_Id", "dbo.Accounts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Plates", "Account_Id", "dbo.Accounts");
            DropIndex("dbo.Plates", new[] { "Account_Id" });
            DropColumn("dbo.Plates", "Account_Id");
        }
    }
}
