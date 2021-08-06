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
    public class ReservationBLL
    {
        ReservationDAL ReservationDAL;

        public ReservationBLL()
        {
            ReservationDAL = new ReservationDAL();
        }

        public List<eReservation> getAllReservation()
        {
            return ReservationDAL.getAllReservation();
        }
        public IEnumerable getAllCustomerReservations(int id)
        {
            return ReservationDAL.getAllCustomerReservations(id);
        }
        public bool setOnHold(string title, int? diskID)
        {
            return ReservationDAL.setOnHold(title, diskID);
        }
        public IList getDiskOnHod(int id)
        {
            return ReservationDAL.getDiskOnHod(id);
        }
        public void addReservation(eReservation e)
        {
            ReservationDAL.addReservation(e);
        }
        public void deleteReservation(int id)
        {
            ReservationDAL.deleteReservation(id);
        }
        public void deleteReservationByDiskID(int id)
        {
            ReservationDAL.deleteReservationByDiskID(id);
        }
        public eReservation findReservation(int id)
        {
            return ReservationDAL.findReservation(id);
        }
        public void editReservation(eReservation ReservationType)
        {
            ReservationDAL.editReservation(ReservationType);
        }
    }
}
