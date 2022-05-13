namespace EmailSender.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Message_Id", c => c.Int());
            CreateIndex("dbo.Messages", "Message_Id");
            AddForeignKey("dbo.Messages", "Message_Id", "dbo.Messages", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "Message_Id", "dbo.Messages");
            DropIndex("dbo.Messages", new[] { "Message_Id" });
            DropColumn("dbo.Messages", "Message_Id");
        }
    }
}
