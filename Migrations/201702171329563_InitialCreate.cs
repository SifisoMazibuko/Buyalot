namespace Buyalot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        addressID = c.Int(nullable: false, identity: true),
                        customerID = c.Int(nullable: false),
                        address = c.String(),
                        city = c.String(),
                        postalCode = c.String(),
                    })
                .PrimaryKey(t => t.addressID)
                .ForeignKey("dbo.Customer", t => t.customerID, cascadeDelete: true)
                .Index(t => t.customerID);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        customerID = c.Int(nullable: false, identity: true),
                        firstName = c.String(nullable: false),
                        lastName = c.String(nullable: false),
                        phone = c.String(nullable: false),
                        email = c.String(nullable: false),
                        password = c.String(nullable: false, maxLength: 100),
                        confirmPassword = c.String(),
                        state = c.String(),
                    })
                .PrimaryKey(t => t.customerID);
            
            CreateTable(
                "dbo.Billing",
                c => new
                    {
                        billingID = c.Int(nullable: false, identity: true),
                        customerID = c.Int(nullable: false),
                        cardNumber = c.String(),
                        cardType = c.String(),
                        expDate = c.DateTime(nullable: false),
                        cardHolderName = c.String(),
                    })
                .PrimaryKey(t => t.billingID)
                .ForeignKey("dbo.Customer", t => t.customerID, cascadeDelete: true)
                .Index(t => t.customerID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        orderID = c.Int(nullable: false, identity: true),
                        customerID = c.Int(nullable: false),
                        orderDate = c.DateTime(nullable: false),
                        shippingDate = c.String(),
                        shippingAddress = c.DateTime(nullable: false),
                        status = c.String(),
                        totalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.orderID)
                .ForeignKey("dbo.Customer", t => t.customerID, cascadeDelete: true)
                .Index(t => t.customerID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        orderDetailsID = c.Int(nullable: false, identity: true),
                        orderID = c.Int(nullable: false),
                        productID = c.Int(nullable: false),
                        quantityOrdered = c.Int(nullable: false),
                        priceEach = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.orderDetailsID)
                .ForeignKey("dbo.Order", t => t.orderID, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.productID, cascadeDelete: true)
                .Index(t => t.orderID)
                .Index(t => t.productID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        productID = c.Int(nullable: false, identity: true),
                        productName = c.String(nullable: false),
                        productDescription = c.String(nullable: false),
                        vendor = c.String(nullable: false),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        quantityInStock = c.Int(nullable: false),
                        productImage = c.Binary(),
                        ProductCategoryModel_prodCategoryID = c.Int(),
                        ProductCategory_prodCategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.productID)
                .ForeignKey("dbo.ProductCategory", t => t.ProductCategoryModel_prodCategoryID)
                .ForeignKey("dbo.ProductCategory", t => t.ProductCategory_prodCategoryID)
                .Index(t => t.ProductCategoryModel_prodCategoryID)
                .Index(t => t.ProductCategory_prodCategoryID);
            
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        prodCategoryID = c.Int(nullable: false, identity: true),
                        adminID = c.Int(nullable: false),
                        categoryName = c.String(),
                        ProductModel_productID = c.Int(),
                    })
                .PrimaryKey(t => t.prodCategoryID)
                .ForeignKey("dbo.Admin", t => t.adminID, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductModel_productID)
                .Index(t => t.adminID)
                .Index(t => t.ProductModel_productID);
            
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        adminID = c.Int(nullable: false, identity: true),
                        adminName = c.String(),
                        email = c.String(nullable: false),
                        password = c.String(nullable: false, maxLength: 100),
                        confirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.adminID);
            
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        paymentID = c.Int(nullable: false, identity: true),
                        customerID = c.Int(nullable: false),
                        paymentDate = c.DateTime(nullable: false),
                        paymentType = c.String(),
                        totalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.paymentID)
                .ForeignKey("dbo.Customer", t => t.customerID, cascadeDelete: true)
                .Index(t => t.customerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payment", "customerID", "dbo.Customer");
            DropForeignKey("dbo.Product", "ProductCategory_prodCategoryID", "dbo.ProductCategory");
            DropForeignKey("dbo.OrderDetails", "productID", "dbo.Product");
            DropForeignKey("dbo.ProductCategory", "ProductModel_productID", "dbo.Product");
            DropForeignKey("dbo.Product", "ProductCategoryModel_prodCategoryID", "dbo.ProductCategory");
            DropForeignKey("dbo.ProductCategory", "adminID", "dbo.Admin");
            DropForeignKey("dbo.OrderDetails", "orderID", "dbo.Order");
            DropForeignKey("dbo.Order", "customerID", "dbo.Customer");
            DropForeignKey("dbo.Billing", "customerID", "dbo.Customer");
            DropForeignKey("dbo.Address", "customerID", "dbo.Customer");
            DropIndex("dbo.Payment", new[] { "customerID" });
            DropIndex("dbo.ProductCategory", new[] { "ProductModel_productID" });
            DropIndex("dbo.ProductCategory", new[] { "adminID" });
            DropIndex("dbo.Product", new[] { "ProductCategory_prodCategoryID" });
            DropIndex("dbo.Product", new[] { "ProductCategoryModel_prodCategoryID" });
            DropIndex("dbo.OrderDetails", new[] { "productID" });
            DropIndex("dbo.OrderDetails", new[] { "orderID" });
            DropIndex("dbo.Order", new[] { "customerID" });
            DropIndex("dbo.Billing", new[] { "customerID" });
            DropIndex("dbo.Address", new[] { "customerID" });
            DropTable("dbo.Payment");
            DropTable("dbo.Admin");
            DropTable("dbo.ProductCategory");
            DropTable("dbo.Product");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Order");
            DropTable("dbo.Billing");
            DropTable("dbo.Customer");
            DropTable("dbo.Address");
        }
    }
}
