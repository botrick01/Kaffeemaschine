using Microsoft.AspNetCore.Mvc;

namespace Kaffemaschine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KaffeeController : ControllerBase
    {
        /*
        Kaffeemaschine maschine;

        public KaffeeController(Kaffeemaschine maschine)
        {
            this.maschine = maschine;
        }
        */
        [HttpPost(Name = "createMaschine")]
        public Kaffeemaschine createMaschine(Kaffeemaschine maschine)
        {
            using (var context = new context.KaffeemaschineContext())
            {
                context.Kaffeemaschinen.Add(maschine);
                context.SaveChanges();
                return maschine;
            }
        }
        [HttpGet(Name = "get")]
        public Kaffeemaschine getMaschine(int id)
        {
            using (var context = new context.KaffeemaschineContext())
            {
                return context.Kaffeemaschinen.FirstOrDefault(m => m.Id == id);
            }
        }

        [HttpPost]
        [Route("wasserAuffuellen/{menge:double}")]
        public IActionResult wasserAuffuellenEndpoint(int id, double menge)
        {
            using (var context = new context.KaffeemaschineContext())
            {
                var maschine = context.Kaffeemaschinen.FirstOrDefault(m => m.Id == id);
                double wasserstand = maschine.Wasser;
                maschine.wasserAuffuellen(menge);
                context.SaveChanges();
                if (wasserstand == maschine.Wasser)
                {
                    return Conflict("Menge " + menge + " konnte nicht aufgefüllt werden. Wasserstand: " + wasserstand);
                }
                return Ok(maschine.Wasser);
            }
        }

        [HttpPost]
        [Route("bohnenAuffuellen/{menge:double}")]
        public IActionResult bohnenAuffuellenEndpoint(int id, double menge)
        {
            using (var context = new context.KaffeemaschineContext())
            {
                var maschine = context.Kaffeemaschinen.FirstOrDefault(m => m.Id == id);
                double bohnenstand = maschine.Kaffebohnen;
                maschine.bohnenAuffuellen(menge);
                context.SaveChanges();
                if (bohnenstand == maschine.Kaffebohnen)
                {
                    return Conflict("Menge " + menge + " konnte nicht aufgefüllt werden. Bohnenstand: " + bohnenstand);
                }
                return Ok(maschine.Kaffebohnen);
            }
        }

        [HttpPost]
        [Route("kaffeemachen")]
        public IActionResult kaffemachen(int id, double menge, double verhaeltnis)
        {
            using(var context = new context.KaffeemaschineContext())
            {
                var maschine = context.Kaffeemaschinen.FirstOrDefault(m => m.Id == id);
                bool kaffee = maschine.macheKaffee(menge, verhaeltnis);
                context.SaveChanges();
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
}