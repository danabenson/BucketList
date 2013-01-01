namespace FacebookBucketList.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relations_fix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Id", "dbo.Buckets");
            DropForeignKey("dbo.BucketItems", "Bucket_Id", "dbo.Buckets");
            DropIndex("dbo.Users", new[] { "Id" });
            DropIndex("dbo.BucketItems", new[] { "Bucket_Id" });
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Buckets", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.BucketItems", "Bucket_Id", c => c.Int(nullable: false));
            AddForeignKey("dbo.Buckets", "Id", "dbo.Users", "Id");
            AddForeignKey("dbo.BucketItems", "Bucket_Id", "dbo.Buckets", "Id", cascadeDelete: true);
            CreateIndex("dbo.Buckets", "Id");
            CreateIndex("dbo.BucketItems", "Bucket_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.BucketItems", new[] { "Bucket_Id" });
            DropIndex("dbo.Buckets", new[] { "Id" });
            DropForeignKey("dbo.BucketItems", "Bucket_Id", "dbo.Buckets");
            DropForeignKey("dbo.Buckets", "Id", "dbo.Users");
            AlterColumn("dbo.BucketItems", "Bucket_Id", c => c.Int());
            AlterColumn("dbo.Buckets", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false));
            CreateIndex("dbo.BucketItems", "Bucket_Id");
            CreateIndex("dbo.Users", "Id");
            AddForeignKey("dbo.BucketItems", "Bucket_Id", "dbo.Buckets", "Id");
            AddForeignKey("dbo.Users", "Id", "dbo.Buckets", "Id");
        }
    }
}
