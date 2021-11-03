using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareHW.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        List<string> Summaries = new List<string>{
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        List<string> Cars = new List<string>{
            "BMW", "Chevrolet", "Geely"
        };
  
        [HttpGet]
        [Route("summaries")]
        [ExtraHeader(key: "KKK", value: "VVV")]
        public IEnumerable<string> Get()
        {
            return Summaries;
        }

        [HttpGet]
        [Route("cars")]
        public IEnumerable<string> GetCars()
        {
            return Cars;
        }
    }
}
