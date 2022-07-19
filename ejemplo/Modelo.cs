using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemplo
{
    public class Rates
    {
        public double MXN { get; set; }
        public double EUR { get; set; }
        public double BTC { get; set; }
    }

    public class Root
    {
        public string @base { get; set; }
        public string date { get; set; }
        public Rates rates { get; set; }
        public bool success { get; set; }
        public int timestamp { get; set; }
    }
}
