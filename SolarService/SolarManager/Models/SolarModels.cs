using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace SolarManager.Models
{
    public class SolarContext
    {
        public int gridState { get; set; }
        public int panelProduction { get; set; }
        public int muxSelect { get; set; }
        public int muxEnergy { get; set; }

        public SolarContext()
        {
            //JSON GET Requests
            var jsonGridStateString = new WebClient().DownloadString("http://gsd.itu.dk/api/user/measurement/?uuid=energy-grid-state&limit=1&order_by=-timestamp");
            var jsonPanelProductionString = new WebClient().DownloadString("http://gsd.itu.dk/api/user/measurement/?uuid=energy-panel-production&limit=1&order_by=-timestamp");
            var jsonMuxSelectString = new WebClient().DownloadString("http://gsd.itu.dk/api/user/measurement/?uuid=energy-mux-select&limit=1&order_by=-timestamp");
            var jsonMuxEnergyString = new WebClient().DownloadString("http://gsd.itu.dk/api/user/measurement/?uuid=energy-mux-energy&limit=1&order_by=-timestamp");
        
            //Parse JSON
            dynamic jsonGridState = JValue.Parse(jsonGridStateString);
            dynamic jsonPanelProduction = JValue.Parse(jsonPanelProductionString);
            dynamic jsonMuxSelect = JValue.Parse(jsonMuxSelectString);
            dynamic jsonMuxEnergy = JValue.Parse(jsonMuxEnergyString);

            //store to context
            this.gridState = jsonGridState.state;
            this.panelProduction = jsonPanelProduction.output;
            this.muxSelect = jsonMuxSelect.sel;
            this.muxEnergy = jsonMuxEnergy.accepted;
        }
    }
}