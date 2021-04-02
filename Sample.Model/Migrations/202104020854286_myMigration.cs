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
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        barcode = c.String(),
                        price = c.Double(nullable: false),
                        pictures = c.String(),
                        description = c.String(),
                        quantity = c.Int(nullable: false),
                        owner = c.Int(),
                        created_by = c.Int(),
                        updated_by = c.Int(),
                        created_at = c.DateTime(nullable: false),
                        updated_at = c.DateTime(),
                        deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        surename = c.String(),
                        phone = c.String(),
                        email = c.String(),
                        password = c.String(),
                        has_admin_rights = c.Boolean(nullable: false),
                        owner = c.Int(),
                        created_by = c.Int(),
                        updated_by = c.Int(),
                        created_at = c.DateTime(nullable: false),
                        updated_at = c.DateTime(),
                        deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Products");
        }
    }
}
