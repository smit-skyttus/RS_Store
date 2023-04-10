using InfiGrowth.Entity.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiGrowth.Entity.Manage
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")] 
        public virtual Categories Category { get; set; }
        public List<Images> Images { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; } 
        public string ProductImage { get; set; }
        //public List<Colors> ProductColors { get; set; }
        public string ProductDescription { get; set; }
        public Boolean Featured { get; set; }
    }
}
