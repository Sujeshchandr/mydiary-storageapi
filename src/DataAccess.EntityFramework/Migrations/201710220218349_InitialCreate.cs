namespace DataAccess.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "ebook.EbookDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Prize = c.Double(nullable: false),
                        PublishedDate = c.DateTimeOffset(precision: 7),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedDate = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("ebook.EbookDetails");
        }
    }
}
