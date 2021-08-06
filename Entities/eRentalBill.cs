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
    [Table("RentalBill")]
    public class eRentalBill
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int rentalBillId { get; set; }
        public DateTime hireDate { get; set; }
        public DateTime paymentTerm { get; set; }
        public DateTime payDate { get; set; }


        [ForeignKey("Customer")]
        public int customerID { get; set; }
        public virtual eCustomer Customer { get; set; }

        [ForeignKey("Disk")]
        public int diskId { get; set; }
        public virtual eDisk Disk { get; set; }

        //Liên kết phí trễ
        public virtual ICollection<eLateCharge> LateCharges { get; set; }
        //public virtual eLateCharge LateCharges { get; set; }
    }
}
