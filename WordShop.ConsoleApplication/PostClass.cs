using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordShop.ConsoleApplication
{
    public class PostClass
    {
        public string? postcode { get; set; }
        public double? latitude { get; set; }
        public double? longitude { get; set; }
        public string? city { get; set; }
        public string? country { get; set; }
        public string? county { get; set; }
        public int? Range { get; set; }
    }
}
