using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace RESTService.Models
{
    public class Consumption
    {
        public float currentValue;
        public Level level;

        public Consumption()
        {
            using (var client = new WebClient())
            {
                string url = "http://gsd.itu.dk/api/user/measurement/?bid=0&uuid=energy-mux-energy&limit=1&format=json";
                
                var response = client.DownloadString(new Uri(url));
                JObject jObject = JObject.Parse(response);
                JToken jConsumption = jObject["objects"];
                this.currentValue = (float)jConsumption[0]["val"];
                
                //TODO: assign level
                this.level = Level.medium; 
            }
        }
    }
}