namespace FacebookBucketList.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stuf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ProfileImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "ProfileImageUrl");
        }
    }
}
