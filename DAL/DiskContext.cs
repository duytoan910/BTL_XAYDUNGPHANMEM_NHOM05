using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    class DiskContext : DbContext
    {
        public DiskContext() : base("DiskConnectionDb") { }

        public DbSet<eDiskType> DiskTypes { get; set; }
        public DbSet<eDisk> Disks { get; set; }
        public DbSet<eDiskTitle> DiskTitles { get; set; }
        public DbSet<eCustomer> Customers { get; set; }
        public DbSet<eRentalBill> RentalBills { get; set; }
        public DbSet<eLateCharge> LateCharges { get; set; }
        public DbSet<eReservation> Reservations { get; set; }
    }
}
