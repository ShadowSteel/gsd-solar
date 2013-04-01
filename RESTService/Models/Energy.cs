using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTService.Models
{
    [Serializable]
    public class Energy
    {
        private float gridValue;
        private Source currentSource;
        private float consumptionValue;
        private Level consumptionLevel;
        private float productionValue;
        private Level productionLevel;
        private float batteryValue;
        private Level batteryLevel;

        public Energy()
        {
            Battery battery = new Battery();
            Consumption consumption = new Consumption();
            Grid grid = new Grid();
            Production production = new Production();
            Multiplexer multiplexer = new Multiplexer();

            this.batteryValue = battery.currentValue;
            this.batteryLevel = battery.level;
            this.consumptionValue = consumption.currentValue;
            this.consumptionLevel = consumption.level;
            this.gridValue = grid.currentValue;
            this.productionValue = production.currentValue;
            this.productionLevel = production.level;
            this.currentSource = multiplexer.currentSource;
        }
    }
}