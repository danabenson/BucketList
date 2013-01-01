namespace FacebookBucketList.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class completed_not_required : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BucketItems", "Completed", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BucketItems", "Completed", c => c.DateTime(nullable: false));
        }
    }
}
