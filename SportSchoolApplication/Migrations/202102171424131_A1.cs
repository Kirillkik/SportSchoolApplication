namespace SportSchoolApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PhotoPath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhotoPath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhotoGalleries",
                c => new
                    {
                        Photo_Id = c.Int(nullable: false),
                        Gallery_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Photo_Id, t.Gallery_Id })
                .ForeignKey("dbo.Photos", t => t.Photo_Id, cascadeDelete: true)
                .ForeignKey("dbo.Galleries", t => t.Gallery_Id, cascadeDelete: true)
                .Index(t => t.Photo_Id)
                .Index(t => t.Gallery_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhotoGalleries", "Gallery_Id", "dbo.Galleries");
            DropForeignKey("dbo.PhotoGalleries", "Photo_Id", "dbo.Photos");
            DropIndex("dbo.PhotoGalleries", new[] { "Gallery_Id" });
            DropIndex("dbo.PhotoGalleries", new[] { "Photo_Id" });
            DropTable("dbo.PhotoGalleries");
            DropTable("dbo.Photos");
            DropTable("dbo.Galleries");
        }
    }
}
