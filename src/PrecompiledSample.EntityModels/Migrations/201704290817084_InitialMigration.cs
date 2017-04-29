namespace PrecompiledSample.EntityModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        DateUpdated = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Product");
        }
    }
}
