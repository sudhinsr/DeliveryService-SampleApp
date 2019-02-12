namespace DeliveryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        IsNewCustomer = c.Boolean(nullable: false),
                        IsGoldenCustomer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Coupon = c.String(),
                        CustomerId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Distance = c.Int(nullable: false),
                        NoOfFloors = c.Int(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        BasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NewCustomerPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GoldenCustomerPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CouponPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WeekendPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price10Km = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price50Km = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceEachKm = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price5Floor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceEachFloor = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Product");
            DropTable("dbo.Order");
            DropTable("dbo.Customer");
        }
    }
}
