using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiGrowth.Entity.Manage
{
    public class Seller
    {
        [Key]
        public int SellerId { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Products products { get; set; }
        public string Name { get; set; }
    }
}
