namespace DAL2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Accounts", "Login", unique: true, name: "TitleIndex");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Accounts", "TitleIndex");
        }
    }
}
