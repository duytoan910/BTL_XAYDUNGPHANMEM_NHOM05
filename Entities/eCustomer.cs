using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Customer")]
    public class eCustomer
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int customerID { get; set; }
        public string customerName { get; set; }
        public string customerAddress { get; set; }
        public string customerPhone { get; set; }

        //Nối đến RentalBill
        public virtual ICollection<eRentalBill> RentalBills { get; set; }

        //Nối đến Reservation
        public virtual ICollection<eReservation> Reservations { get; set; }
    }
}
