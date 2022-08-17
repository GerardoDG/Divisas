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

    public class Query
    {
        public string from { get; set; }//moneda de cambio base
        public string to { get; set; }//moneda de cambio dirección
        public double amount { get; set; }//cantidad que se cambiará
    }

    public class Info
    {
        public int timestamp { get; set; }//tiempo de ejecucion
        public double rate { get; set; }//tipo de cambio
    }

    public class List
    {
        public bool success { get; set; } //si el proceso resulto bien
        public Query query { get; set; }//ver clase query
        public Info info { get; set; }//ver clase info
        public string date { get; set; }//fecha de realización de transacción
        public double result { get; set; }//monto total en moneda de cambio dirección
    }

    

}
