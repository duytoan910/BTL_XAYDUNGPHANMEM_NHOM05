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
    public class RentalBillBLL
    {
        RentalBillDAL lcDAL;

        public RentalBillBLL()
        {
            lcDAL = new RentalBillDAL();
        }

        public List<eRentalBill> getRentalBill()
        {
            return lcDAL.getRentalBill();
        }
        public IEnumerable getRentalBillDetail()
        {
            return lcDAL.getRentalBillDetail();
        }
        public IList getRentalBillDetailByID(int cusID)
        {
            return lcDAL.getRentalBillDetailByID(cusID);
        }
        public IList getOverdueRentalBillByID(int cusID)
        {
            return lcDAL.getOverdueRentalBillByID(cusID);
        }
        public void addRentalBill(eRentalBill e)
        {
            lcDAL.addRentalBill(e);
        }
        public void deleteRentalBill(eRentalBill e)
        {
            lcDAL.deleteRentalBill(e);
        }
        public eRentalBill findRentalBill(int id)
        {
            return lcDAL.findRentalBill(id);
        }
        public void editRentalBill(eRentalBill c)
        {
            lcDAL.editRentalBill(c);
        }
        public void setPayDate(int id)
        {
            lcDAL.setPayDate(id);
        }
    }
}
