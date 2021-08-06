using Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DiskTitleDAL
    {
        DiskContext db;

        public DiskTitleDAL()
        {
            db = new DiskContext();
        }

        public IEnumerable getAllDiskTitleForLoad()
        {
            var listEmpl = (from m in db.DiskTitles
                            select new
                            {
                                ID = m.diskTitleId,
                                Name = m.diskTitleName,
                                NameType = m.DiskType.diskName,
                            }).ToList();
            return listEmpl;
        }

        public List<eDiskTitle> getAllDiskTitle()
        {
            return db.DiskTitles.ToList();
        }

        public bool addDiskTitle(eDiskTitle e)
        {
            var s = db.DiskTypes.Where(x => x.diskName == e.DiskType.diskName).FirstOrDefault();

            eDiskTitle add = new eDiskTitle();
            add.diskTitleId = e.diskTitleId;
            add.diskTitleName = e.diskTitleName;
            add.diskTypeId = s.diskTypeId;

            db.DiskTitles.Add(add);
            db.SaveChanges();
            return true;
        }

        public bool deleteDiskTitle(int id)
        {
            eDiskTitle de = db.DiskTitles.Find(id);
            if (de == null)
                return false;

            db.DiskTitles.Remove(de);
            db.SaveChanges();
            return true;
        }

        public eDiskTitle findDiskTitle(int id)
        {
            eDiskTitle DiskTitle = db.DiskTitles.Find(id);
            return DiskTitle;
        }

        public void editDiskTitle(eDiskTitle e)
        {
            var s = db.DiskTypes.Where(x => x.diskName == e.DiskType.diskName).FirstOrDefault();

            eDiskTitle edit = findDiskTitle(e.diskTitleId);

            edit.diskTitleName = e.diskTitleName;
            edit.diskTypeId = s.diskTypeId;

            db.Entry(edit).State = EntityState.Modified;
            db.SaveChanges();
        }

        public bool checkTitleIfExist(string title)
        {
            eDiskTitle c = db.DiskTitles.Where(x => x.diskTitleName == title).FirstOrDefault();

            if (c != null)
                return true;
            return false;
        }

        //TẠO THỐNG KÊ
        public int CountDisk(int titleID) //Số bản sao
        {
            var list = (from m in db.Disks
                        where m.diskTitleId == titleID
                        select m).ToList();
            return list.Count;
        }

        public int CountInstock(int titleID) //Đang trên kệ
        {
            var list = (from m in db.Disks
                        where m.status == "Trên kệ" && m.diskTitleId == titleID
                        select m).ToList();
            return list.Count;
        }

        public int CountRent(int titleID) //Đang cho thuê
        {
            var list = (from m in db.Disks
                        where m.status == "Cho thuê" && m.diskTitleId == titleID
                        select m).ToList();
            return list.Count;
        }

        public int CountOnHold(int titleID) //Đang giữ
        {
            var list = (from m in db.Disks
                        where m.status == "Đang chờ" && m.diskTitleId == titleID
                        select m).ToList();
            return list.Count;
        }

        public int CountReservation(int titleID) //Tựa được đặt
        {
            var list = (from m in db.Reservations
                        where m.diskTitleId == titleID 
                        select m).ToList();
            return list.Count;
        }
    }
}
