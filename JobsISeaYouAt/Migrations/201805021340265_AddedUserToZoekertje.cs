namespace JobsISeaYouAt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserToZoekertje : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Zoekertjes", "AanbiederID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Zoekertjes", "AanbiederID");
        }
    }
}
