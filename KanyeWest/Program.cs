using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace KanyeWest
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var kanyeURL = "https://api.kanye.rest";
            var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

            Console.WriteLine(kanyeQuote);
            Console.WriteLine();

            var ronur1 = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

            for (int i = 0; i < 5; i++)
            {
                var ronresponse = client.GetStringAsync(ronur1).Result;
                var ronquote = JArray.Parse(ronresponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();

                kanyeResponse = client.GetStringAsync(kanyeURL).Result;
                kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

                Console.WriteLine($"ron:{ronquote}\n kanye:{ kanyeQuote}");
                Console.WriteLine();
            }

        }


    }

}
