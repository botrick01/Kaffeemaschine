using Microsoft.AspNetCore.Mvc;

namespace Kaffemaschine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KaffeeController : ControllerBase
    {
        static Kaffemaschine maschine = new Kaffemaschine(1.2, 0.8);

        [HttpGet(Name = "get")]
        public Kaffemaschine getMaschine()
        {
            return maschine;
        }

        [HttpPost]
        [Route("wasserAuffuellen/{menge:double}")]
        public IActionResult wasserAuffuellenEndpoint(double menge)
        {
            double wasserstand = maschine.Wasser;
            maschine.wasserAuffuellen(menge);
            if (wasserstand == maschine.Wasser)
            {
                return Conflict("Menge " + menge + " konnte nicht aufgefüllt werden. Wasserstand: " + wasserstand);
            }
            return Ok(maschine.Wasser);
        }

        [HttpPost]
        [Route("bohnenAuffuellen/{menge:double}")]
        public IActionResult bohnenAuffuellenEndpoint(double menge)
        {
            double bohnenstand = maschine.Kaffebohnen;
            maschine.bohnenAuffuellen(menge);
            if (bohnenstand == maschine.Kaffebohnen)
            {
                return Conflict("Menge " + menge + " konnte nicht aufgefüllt werden. Bohnenstand: " + bohnenstand);
            }
            return Ok(maschine.Kaffebohnen);
        }

        [HttpPost]
        [Route("kaffeemachen")]
        public IActionResult kaffemachen(double menge, double verhaeltnis)
        {
            bool kaffee = maschine.macheKaffee(menge, verhaeltnis);
            if (kaffee)
            {
                return Ok("Kaffee gemacht");
            }
            else
            {
                return Ok("Nicht genug Zutaten");
            }
        }

    }
}