using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Timers;

namespace Client
{
    class Program
    {
        static string baseAddress = "http://localhost:1412/";
        static HttpClient client = new HttpClient() { BaseAddress = new Uri(baseAddress) };
        static int interval = 15000;

        public static void Repeater()
        {
            Console.WriteLine("Client received: {0}", client.GetStringAsync("api/energy").Result);
            Console.WriteLine();
        }
        
        static void Main(string[] args)
        {
            var timer = new Timer(interval);
            timer.Elapsed += (s, e) => Repeater();
            timer.Start();
            Console.ReadLine();
        }
    }
}
