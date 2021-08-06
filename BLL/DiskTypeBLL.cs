using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DiskTypeBLL
    {
        DiskTypeDAL diskTypeDAL;

        public DiskTypeBLL()
        {
            diskTypeDAL = new DiskTypeDAL();
        }

        public List<eDiskType> getAllDiskType()
        {
            return diskTypeDAL.getAllDiskType();
        }

        public eDiskType getGameType()
        {
            return diskTypeDAL.getGameType();
        }

        public eDiskType getMovieType()
        {
            return diskTypeDAL.getMovieType();
        }
        public void addDiskType(eDiskType e)
        {
            diskTypeDAL.addDiskType(e);
        }
        public void deleteDiskType(eDiskType e)
        {
            diskTypeDAL.deleteDiskType(e);
        }
        public eDiskType findDiskType(string id)
        {
            return diskTypeDAL.findDiskType(id);
        }
        public void editDiskType(eDiskType DiskType)
        {
            diskTypeDAL.editDiskType(DiskType);
        }
    }
}
