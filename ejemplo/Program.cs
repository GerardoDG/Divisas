using RestSharp;
using Newtonsoft.Json;
using System.Net;
using ejemplo;
using System;

class Program
{
    static void Main(string[] args)
    {   
        double montocomision, tipocambio, montotransaccion;
        int opc;
        Boolean repetir = false;
        
        do
        {
            Console.WriteLine("Cambio de divisas!");
            string monedabase = from();
            string monedacambio = to();
            double monto = Monto();
            Console.Clear();
            (montocomision, tipocambio, montotransaccion) = consultaAPI(monto, monedabase, monedacambio);
            resultados(monedabase, monedacambio, monto, montocomision, tipocambio, montotransaccion);
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("¿Deseas realizar una nueva transacción?");
            Console.WriteLine("1.Si");
            Console.WriteLine("2.No");
            opc = int.Parse(Console.ReadLine());
            if (opc==1)
            {
                repetir = true;
                Console.Clear();
            }
            else
            {
                repetir =false;
            }
        } while (repetir == true);
        
        
    }
    static string from()
    {
        Console.WriteLine("Ingresa la moneda base de cambio (USD, MXN, EUR, BTC)");
        var from = Console.ReadLine();
        return from;
    }

    static string to()
    {
        Console.WriteLine("Ingresa la moneda de cambio que se busca (USD, MXN, EUR, BTC)");
        var to = Console.ReadLine();
        return to;
    }
    static double Monto()
    {
        Console.WriteLine("Ingresa la cantidad de la cual deseas realizar el cambio");
        var monto = double.Parse(Console.ReadLine());
        return monto;
    }

    static double Comision(double montototal)
    {
        var comision = montototal * .05;
        return comision;
    }

    static void resultados(string monedabase, string monedacambio, double monto, double montocomision, double tipocambio, double montotransaccion)
    {
        string datetime = DateTime.Now.ToString("T");
        Console.WriteLine("Cambio de divisas!");
        Console.WriteLine("La moneda de cambio base es: " + monedabase);
        Console.WriteLine("La moneda a cambio es: " + monedacambio);
        Console.WriteLine("El monto que se desea cambiar es: " + monto);
        Console.WriteLine("El monto de la transacción es: " + montotransaccion);
        Console.WriteLine("El monto de comisión por la transacción es: " + montocomision);
        Console.WriteLine("El tipo de cambio que se esta ultizando es: " + tipocambio);
        Console.WriteLine("La hora en que se realizo esta operación es: "+datetime);
        
    }


    static (double, double, double) consultaAPI(double monto, string from, string to)
    {
        var client = new RestClient("https://api.apilayer.com/exchangerates_data/convert?to=" + to + "&from=" + from + "&amount=" + monto);
        RestRequest request = new RestRequest();
        request.AddHeader("apikey", "eA2FoPNIG4Vg0FYj1RUEIRU540Ugvgtn");
        var response = client.Execute(request);
        List resultados = JsonConvert.DeserializeObject<List>(response.Content);
        var montotransaccion = resultados.result;
        var montocomision = Comision(resultados.result);
        var tipocambio = resultados.info.rate;
        return (montocomision, tipocambio, montotransaccion);
    }
}