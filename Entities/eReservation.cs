using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Reservation")]
    public class eReservation
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public DateTime dateOrder { get; set; }

        [ForeignKey("DiskTitle")]
        public int diskTitleId { get; set; }
        public virtual eDiskTitle DiskTitle { get; set; }

        [ForeignKey("Customer")]
        public int customerID { get; set; }
        public virtual eCustomer Customer { get; set; }

        [ForeignKey("Disk")]
        public int? diskId { get; set; }
        public virtual eDisk Disk { get; set; }
    }
}
