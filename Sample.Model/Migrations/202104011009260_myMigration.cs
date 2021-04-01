namespace Sample.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class myMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Barcode = c.String(),
                        Price = c.Double(nullable: false),
                        Pictures = c.String(),
                        Description = c.String(),
                        Quantity = c.Int(nullable: false),
                        Owner = c.Int(),
                        CreatedById = c.Int(),
                        UpdatedById = c.Int(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SureName = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        HasAdminRights = c.Boolean(nullable: false),
                        Owner = c.Int(),
                        CreatedById = c.Int(),
                        UpdatedById = c.Int(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Products");
        }
    }
}
