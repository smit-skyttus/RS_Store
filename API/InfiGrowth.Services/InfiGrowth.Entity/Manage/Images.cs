using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiGrowth.Entity.Manage
{
    public class Images
    {
        [Key]
        public int ImageId { get; set; }
        public string Link {  get; set; } 
        public int Height { get; set; }
        public int Width { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public string Type { get; set; }

    }
}
