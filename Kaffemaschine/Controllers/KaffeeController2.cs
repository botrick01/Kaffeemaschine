using Microsoft.AspNetCore.Mvc;

namespace Kaffemaschine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KaffeeController2 : ControllerBase
    {
        Kaffeemaschine maschine;

        public KaffeeController2(Kaffeemaschine maschine)
        {
            this.maschine = maschine;
        }


        [HttpGet(Name = "getWater")]
        public double getMaschine()
        {
            return maschine.Wasser;
        }
    }
}