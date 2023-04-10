using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiGrowth.Entity.Manage
{
    public class pro
    {
        public string id { get; set; }
        public string name { get; set; }
        public string company { get; set; }
        public int price { get; set; }
        public List<string> colors { get; set; }

        public string image { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public Boolean shipping { get; set; }
    }
}
