using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiGrowth.Entity.Manage
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Products products { get; set; }
        public DateTime Date { get; set; }
    }
}
