using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace nine.Controllers
{
    [Produces("application/json")]
    [Route("api/Index")]
    public class IndexController : Controller
    {
        // GET: api/Index
        [HttpGet]
        public string Get()
        {
            return "Send your jsoan data to http://ninetest.azurewebsites.net/api/values";
        }
    }
}
