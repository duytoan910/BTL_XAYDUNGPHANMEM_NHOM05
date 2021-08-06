using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("DiskTitle")]
    public class eDiskTitle
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int diskTitleId { get; set; }
        public string diskTitleName { get; set; }

        [ForeignKey("DiskType")]
        public string diskTypeId { get; set; }
        public virtual eDiskType DiskType { get; set; }

        //Nối đến Disk
        public virtual ICollection<eDisk> Disks { get; set; }

        //Nối đến Reservation
        public virtual ICollection<eReservation> Reservations { get; set; }

    }
}
