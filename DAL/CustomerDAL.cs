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
    public class CustomerDAL
    {
        DiskContext db;

        public CustomerDAL()
        {
            db = new DiskContext();
        }

        public List<eCustomer> getCustomer()
        {
            return db.Customers.ToList();
        }

        bool CheckOverdue(int idCus)
        {
            var list = (from c in db.RentalBills
                        where c.Disk.status == "Cho thuê" && c.hireDate == c.payDate && c.customerID == idCus && c.paymentTerm < DateTime.Now
                        select c).ToList();

            if (list.Count > 0)
                return true;
            return false;
        }
        //Load danh sách khách hàng có đĩa trễ hạn
        public List<eCustomer> getCustomerByOverdueDisk()
        {
            List<eCustomer> listCus = new List<eCustomer>();
            foreach(eCustomer x in db.Customers.ToList())
            {
                bool result = CheckOverdue(x.customerID);
                if (result == true)
                    listCus.Add(x);
            }          
            return listCus;
        }

        bool CheckLateCharge(int idCus)
        {
            var listCharge = (from c in db.LateCharges
                              where c.RentalBill.customerID == idCus
                              orderby c.status
                              select c).ToList();

            if (listCharge.Count > 0)
                return true;
            return false;
        }
        //Load danh sách khách hàng có phí trễ hạn
        public List<eCustomer> getCustomerByLateCharge()
        {
            List<eCustomer> listCus = new List<eCustomer>();
            foreach (eCustomer x in db.Customers.ToList())
            {
                bool result = CheckLateCharge(x.customerID);
                if (result == true)
                    listCus.Add(x);
            }
            return listCus;
        }

        public void addCustomer(eCustomer e)
        {
            db.Customers.Add(e);
            db.SaveChanges();
        }

        public bool deleteCustomer(int id)
        {
            eCustomer x = findCustomer(id);
            if (x == null)
                return false;

            db.Customers.Remove(x);
            db.SaveChanges();
            return true;
        }

        public eCustomer findCustomer(int id)
        {
            eCustomer c = db.Customers.Find(id);
            return c;
        }

        public void editCustomer(eCustomer c)
        {
            eCustomer x = findCustomer(c.customerID);

            x.customerName = c.customerName;
            x.customerAddress = c.customerAddress;
            x.customerPhone = c.customerPhone;

            db.Entry(x).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
