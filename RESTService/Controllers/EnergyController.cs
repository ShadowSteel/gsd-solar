using RESTService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RESTService.Controllers
{
    public class EnergyController : ApiController
    {
        // GET api/energy
        public Energy Get()
        {
            return new Energy();
        }
    }
}
