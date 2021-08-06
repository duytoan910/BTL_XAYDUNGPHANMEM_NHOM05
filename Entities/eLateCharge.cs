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
    [Table("LateCharge")]
    public class eLateCharge
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int lateChargeId { get; set; }
        public double lateFee { get; set; }
        public bool status { get; set; }

        [ForeignKey("RentalBill")]
        public int rentalBillId { get; set; }
        public virtual eRentalBill RentalBill { get; set; }
    }
}
