namespace smsproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddageMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UsersModels", "UserModel_Id", c => c.Int());
            CreateIndex("dbo.UsersModels", "UserModel_Id");
            AddForeignKey("dbo.UsersModels", "UserModel_Id", "dbo.UsersModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersModels", "UserModel_Id", "dbo.UsersModels");
            DropIndex("dbo.UsersModels", new[] { "UserModel_Id" });
            DropColumn("dbo.UsersModels", "UserModel_Id");
        }
    }
}
