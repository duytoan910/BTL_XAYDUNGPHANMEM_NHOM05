using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CustomerBLL
    {
        CustomerDAL cusDAL;

        public CustomerBLL()
        {
            cusDAL = new CustomerDAL();
        }

        public List<eCustomer> getCustomer()
        {
            return cusDAL.getCustomer();
        }
        public List<eCustomer> getCustomerByOverdueDisk()
        {
            return cusDAL.getCustomerByOverdueDisk();
        }
        public List<eCustomer> getCustomerByLateCharge()
        {
            return cusDAL.getCustomerByLateCharge();
        }
        public void addCustomer(eCustomer e)
        {
            cusDAL.addCustomer(e);
        }
        public bool deleteCustomer(int id)
        {
            return cusDAL.deleteCustomer(id);
        }
        public eCustomer findCustomer(int id)
        {
            return cusDAL.findCustomer(id);
        }
        public void editCustomer(eCustomer c)
        {
            cusDAL.editCustomer(c);
        }
    }
}
