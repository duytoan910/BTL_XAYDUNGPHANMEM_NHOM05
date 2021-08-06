using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DiskTypeDAL
    {
        DiskContext db;

        public DiskTypeDAL()
        {
            db = new DiskContext();
        }

        public List<eDiskType> getAllDiskType()
        {
            return db.DiskTypes.ToList();
        }

        public eDiskType getGameType()
        {
            eDiskType y = (from x in db.DiskTypes
                              where x.diskTypeId == "GAMES"
                              select x).FirstOrDefault();

            if (y != null) {  
                return y;
            }
            return null; 
        }

        public eDiskType getMovieType()
        {
            eDiskType y = (from x in db.DiskTypes
                           where x.diskTypeId == "MOVIES"
                           select x).FirstOrDefault();

            if (y != null)
            {
                return y;
            }
            return null;
        }

        public void addDiskType(eDiskType e)
        {
            db.DiskTypes.Add(e);
            db.SaveChanges();
        }

        public void deleteDiskType(eDiskType e)
        {
            db.DiskTypes.Remove(e);
            db.SaveChanges();
        }

        public eDiskType findDiskType(string id)
        {
            eDiskType DiskType = db.DiskTypes.Find(id);
            return DiskType;
        }

        public void editDiskType(eDiskType x)
        {
            eDiskType y = findDiskType(x.diskTypeId);
            y.rentalCharge = x.rentalCharge;
            y.lateFee = x.lateFee;
            y.rentalPeriod = x.rentalPeriod;

            db.Entry(y).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
