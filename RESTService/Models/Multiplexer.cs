using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace RESTService.Models
{
    public class Multiplexer
    {
        public Source currentSource;

        public Multiplexer()
        {
            using (var client = new WebClient())
            {
                string url = "http://gsd.itu.dk/api/user/measurement/?bid=0&uuid=energy-mux-select&limit=1&format=json";

                var response = client.DownloadString(new Uri(url));
                JObject jObject = JObject.Parse(response);
                JToken jConsumption = jObject["objects"];
                var temp = (int)jConsumption[0]["val"];
                switch (temp)
                {
                    case 0:
                        this.currentSource = Source.grid;
                        break;
                    case 1:
                        this.currentSource = Source.generators;
                        break;
                    case 2:
                        this.currentSource = Source.solar;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Energy source unknown");
                } 
            }
        }

        //TODO: Implement actions
    }
}