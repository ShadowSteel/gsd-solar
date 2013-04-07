using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace RESTService.Models
{   
    public class Battery
    {
        public float currentValue { get; set; }
        public Level level { get; set; }

        public Battery()
        {
            using (var client = new WebClient())
            {
                string url = "http://gsd.itu.dk/api/user/measurement/?bid=0&uuid=energy-battery-3-level&limit=1&format=json";

                try
                {
                    var response = client.DownloadString(new Uri(url));
                    JObject jObject = JObject.Parse(response);
                    JToken jConsumption = jObject["objects"];
                    this.currentValue = (float) jConsumption[0]["val"];

                    if (this.currentValue > 40)
                        this.level = Level.high;
                    else if (this.currentValue > 5)
                        this.level = Level.medium;
                    else
                        this.level = Level.low;
                    }
                catch { throw new HttpException(); }
            }
        }
    }
}