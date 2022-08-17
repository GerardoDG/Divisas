using RestSharp;
using Newtonsoft.Json;
using System.Net;
using ejemplo;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Cambio de divisas!");


        var client = new RestClient("https://api.apilayer.com/exchangerates_data/latest?symbols=EUR,MXN,BTC&base=USD"); //URL de la API
        RestRequest request = new RestRequest();
        request.AddHeader("apikey", "eA2FoPNIG4Vg0FYj1RUEIRU540Ugvgtn");//Modificar segundo parámetro por su llave

        var response = client.Execute(request);
        Root divisas = JsonConvert.DeserializeObject<Root>(response.Content);

        Console.WriteLine(divisas.rates.MXN);//Imprimir precio del dolar en pesos
        Console.WriteLine(divisas.rates.EUR);//Imprimir precio del dolar en euros
        Console.WriteLine(divisas.rates.BTC);//Imprimir precio del dolar en BTC
        Console.WriteLine(divisas.rates.MXN);

        
    }

    static void cambio()
    {

    }

    static void obtenertipo()
    {

    }
    static void transaccion()
    {

    }
    static void comision()
    {

    }

}