using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using nine.Models;

namespace nine.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        //This struct will hold an error message as an object so it can be
        //serialized by Json easier (and cleaner) 
        struct Error
        {
            [JsonProperty("error")] public string Message { get; set; }
        }

        // POST api/values
        [HttpPost]
        [Produces("application/json")]
        public IActionResult Post([FromBody] object value)
        {
            try
            {
                //load the payload json data straight into the payload object
                //the deserialization will handle the json -> class conversion nicely!
                Payload payload = JsonConvert.DeserializeObject<Payload>(value.ToString());
                return Ok(JToken.Parse(payload.response()));
            }
            catch
            {
                //create an Error object so it can be parsed to json.
                Error error = new Error() { Message = "Could not decode request: JSON parsing failed" };
                return BadRequest(JToken.Parse(JsonConvert.SerializeObject(error)));
            }
                
        }
        
    }
}
