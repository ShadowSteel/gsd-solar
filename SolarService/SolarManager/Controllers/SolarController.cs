using SolarManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SolarManager.Controllers
{
    public class SolarController : Controller
    {
        //
        // GET: /Solar/

        public ActionResult Index()
        {
            //run solar data constructor
            SolarContext context = new SolarContext();

            ViewData["gridState"] = context.gridState;
            ViewData["panelProduction"] = context.panelProduction;
            ViewData["activeSource"] = context.gridState;
            ViewData["muxEnergy"] = context.muxEnergy;
            
            return View();
        }

    }
}
