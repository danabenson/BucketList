namespace FacebookBucketList.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FacebookId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buckets", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Buckets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BucketItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Created = c.DateTime(nullable: false),
                        Completed = c.DateTime(nullable: false),
                        Bucket_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buckets", t => t.Bucket_Id)
                .Index(t => t.Bucket_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.BucketItems", new[] { "Bucket_Id" });
            DropIndex("dbo.Users", new[] { "Id" });
            DropForeignKey("dbo.BucketItems", "Bucket_Id", "dbo.Buckets");
            DropForeignKey("dbo.Users", "Id", "dbo.Buckets");
            DropTable("dbo.BucketItems");
            DropTable("dbo.Buckets");
            DropTable("dbo.Users");
        }
    }
}
