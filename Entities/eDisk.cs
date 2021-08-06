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
    [Table("Disk")]
    public class eDisk
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int diskId { get; set; }
        public string status { get; set; }
        public DateTime dateAdd { get; set; }
   
        [ForeignKey("DiskTitle")]
        public int diskTitleId { get; set; }
        public virtual eDiskTitle DiskTitle { get; set; }

        //Liên kết RentalBill
        public virtual ICollection<eRentalBill> RentalBills { get; set; }
    }
}
