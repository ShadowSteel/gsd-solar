using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTService.Models
{
    [Serializable]
    public class Energy
    {
        private float batteryValue;
        private Level batteryLevel;
        private float consumptionValue;
        private Level consumptionLevel;
        private float gridValue;
        private float productionValue;
        private Level productionLevel;
        private Source currentSource;

        public Energy()
        {
            Battery battery = new Battery();
            Consumption consumption = new Consumption();
            Grid grid = new Grid();
            Production production = new Production();
            Multiplexer multiplexer = new Multiplexer();

            this.currentSource = multiplexer.currentSource;
            this.batteryValue = battery.currentValue;
            this.batteryLevel = battery.level;
            this.consumptionValue = consumption.currentValue;
            this.consumptionLevel = consumption.level;
            this.gridValue = grid.currentValue;
            this.productionValue = production.currentValue;
            this.productionLevel = production.level;
        }
    }
}