namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        customerID = c.Int(nullable: false, identity: true),
                        customerName = c.String(),
                        customerAddress = c.String(),
                        customerPhone = c.String(),
                    })
                .PrimaryKey(t => t.customerID);
            
            CreateTable(
                "dbo.RentalBill",
                c => new
                    {
                        rentalBillId = c.Int(nullable: false, identity: true),
                        hireDate = c.DateTime(nullable: false),
                        paymentTerm = c.DateTime(nullable: false),
                        payDate = c.DateTime(nullable: false),
                        customerID = c.Int(nullable: false),
                        diskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.rentalBillId)
                .ForeignKey("dbo.Customer", t => t.customerID, cascadeDelete: true)
                .ForeignKey("dbo.Disk", t => t.diskId, cascadeDelete: true)
                .Index(t => t.customerID)
                .Index(t => t.diskId);
            
            CreateTable(
                "dbo.Disk",
                c => new
                    {
                        diskId = c.Int(nullable: false, identity: true),
                        status = c.String(),
                        dateAdd = c.DateTime(nullable: false),
                        diskTitleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.diskId)
                .ForeignKey("dbo.DiskTitle", t => t.diskTitleId, cascadeDelete: true)
                .Index(t => t.diskTitleId);
            
            CreateTable(
                "dbo.DiskTitle",
                c => new
                    {
                        diskTitleId = c.Int(nullable: false, identity: true),
                        diskTitleName = c.String(),
                        diskTypeId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.diskTitleId)
                .ForeignKey("dbo.DiskType", t => t.diskTypeId)
                .Index(t => t.diskTypeId);
            
            CreateTable(
                "dbo.DiskType",
                c => new
                    {
                        diskTypeId = c.String(nullable: false, maxLength: 128),
                        diskName = c.String(),
                        rentalCharge = c.Double(nullable: false),
                        lateFee = c.Double(nullable: false),
                        rentalPeriod = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.diskTypeId);
            
            CreateTable(
                "dbo.Reservation",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        dateOrder = c.DateTime(nullable: false),
                        diskTitleId = c.Int(nullable: false),
                        customerID = c.Int(nullable: false),
                        diskId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Customer", t => t.customerID, cascadeDelete: true)
                .ForeignKey("dbo.Disk", t => t.diskId)
                .ForeignKey("dbo.DiskTitle", t => t.diskTitleId, cascadeDelete: true)
                .Index(t => t.diskTitleId)
                .Index(t => t.customerID)
                .Index(t => t.diskId);
            
            CreateTable(
                "dbo.LateCharge",
                c => new
                    {
                        lateChargeId = c.Int(nullable: false, identity: true),
                        lateFee = c.Double(nullable: false),
                        status = c.Boolean(nullable: false),
                        rentalBillId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.lateChargeId)
                .ForeignKey("dbo.RentalBill", t => t.rentalBillId, cascadeDelete: true)
                .Index(t => t.rentalBillId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LateCharge", "rentalBillId", "dbo.RentalBill");
            DropForeignKey("dbo.RentalBill", "diskId", "dbo.Disk");
            DropForeignKey("dbo.Disk", "diskTitleId", "dbo.DiskTitle");
            DropForeignKey("dbo.Reservation", "diskTitleId", "dbo.DiskTitle");
            DropForeignKey("dbo.Reservation", "diskId", "dbo.Disk");
            DropForeignKey("dbo.Reservation", "customerID", "dbo.Customer");
            DropForeignKey("dbo.DiskTitle", "diskTypeId", "dbo.DiskType");
            DropForeignKey("dbo.RentalBill", "customerID", "dbo.Customer");
            DropIndex("dbo.LateCharge", new[] { "rentalBillId" });
            DropIndex("dbo.Reservation", new[] { "diskId" });
            DropIndex("dbo.Reservation", new[] { "customerID" });
            DropIndex("dbo.Reservation", new[] { "diskTitleId" });
            DropIndex("dbo.DiskTitle", new[] { "diskTypeId" });
            DropIndex("dbo.Disk", new[] { "diskTitleId" });
            DropIndex("dbo.RentalBill", new[] { "diskId" });
            DropIndex("dbo.RentalBill", new[] { "customerID" });
            DropTable("dbo.LateCharge");
            DropTable("dbo.Reservation");
            DropTable("dbo.DiskType");
            DropTable("dbo.DiskTitle");
            DropTable("dbo.Disk");
            DropTable("dbo.RentalBill");
            DropTable("dbo.Customer");
        }
    }
}
