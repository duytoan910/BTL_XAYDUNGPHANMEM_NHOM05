namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.DiskContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.DiskContext context)
        {
            context.DiskTypes.AddOrUpdate(
               t => t.diskTypeId, AddData.GetDiskTypes().ToArray());
            context.SaveChanges();

            context.DiskTitles.AddOrUpdate(
                kh => kh.diskTitleId, AddData.GetDiskTitles().ToArray());
            context.SaveChanges();

            context.Disks.AddOrUpdate(
                emt => emt.diskId, AddData.GetDisks().ToArray());
            context.SaveChanges();

            context.Customers.AddOrUpdate(
               emt => emt.customerID, AddData.GetCustomer().ToArray());
            context.SaveChanges();

            context.RentalBills.AddOrUpdate(
            emt => emt.rentalBillId, AddData.GetRentalBill().ToArray());
            context.SaveChanges();

            context.LateCharges.AddOrUpdate(
            emt => emt.lateChargeId, AddData.GetLateCharges().ToArray());
            context.SaveChanges();

            context.Reservations.AddOrUpdate(
            emt => emt.id, AddData.GetReservations().ToArray());
            context.SaveChanges();
        }
    }
}
