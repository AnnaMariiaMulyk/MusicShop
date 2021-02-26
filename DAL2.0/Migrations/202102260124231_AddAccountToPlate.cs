namespace DAL2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountToPlate : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Plates", name: "Account_Id", newName: "AccountId");
            RenameIndex(table: "dbo.Plates", name: "IX_Account_Id", newName: "IX_AccountId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Plates", name: "IX_AccountId", newName: "IX_Account_Id");
            RenameColumn(table: "dbo.Plates", name: "AccountId", newName: "Account_Id");
        }
    }
}
