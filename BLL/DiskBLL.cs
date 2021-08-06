using DAL;
using Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DiskBLL
    {
        DiskDAL DAL;

        public DiskBLL()
        {
            DAL = new DiskDAL();
        }

        public IEnumerable getAllDiskForLoad()
        {
            return DAL.getAllDiskForLoad();
        }
        public IEnumerable getAllDiskForLoadOnShelf()
        {
            return DAL.getAllDiskForLoadOnShelf();
        }
        public List<eDisk> getAllDisk()
        {
            return DAL.getAllDisk();
        }

        public eDisk addDisk(eDisk e)
        {
            return DAL.addDisk(e);
        }
        public bool deleteDisk(int e)
        {
            return DAL.deleteDisk(e);
        }
        public eDisk findDisk(int id)
        {
            return DAL.findDisk(id);
        }
        public void editDisk(eDisk Disk)
        {
            DAL.editDisk(Disk);
        }
        public void setStatus(int? id, string status)
        {
            DAL.setStatus(id, status);
        }
        public bool checkStatus(int id, string status)
        {
            return DAL.checkStatus(id, status);
        }
    }
}
