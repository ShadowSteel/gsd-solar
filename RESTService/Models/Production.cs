using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace RESTService.Models
{
    public class Production
    {
        public float currentValue;
        public Level level;

        public Production()
        {
            using (var client = new WebClient())
            {
                string url = "http://gsd.itu.dk/api/user/measurement/?bid=0&uuid=energy-panel-production&limit=1&format=json";

                try
                {
                    var response = client.DownloadString(new Uri(url));
                    JObject jObject = JObject.Parse(response);
                    JToken jConsumption = jObject["objects"];
                    this.currentValue = (float)jConsumption[0]["val"];
                }
                catch { throw new HttpException(); }
            }
        }
    }
}