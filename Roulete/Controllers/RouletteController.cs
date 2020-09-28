using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Roulete_.Models;

namespace Roulete_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RouletteController : ControllerBase
    {
        [HttpPost("CreateRoulette")]
        public JsonResult CreateRoulette()
        {
            DbController dbOps = new DbController();
            int betId = dbOps.createRoulette();

            return Json(Roulette, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public bool OpenRoulette(int id)
        {
            bool result = true;

            return result;
        }

        [HttpPost]
        public bool CloseRoulette()
        {
            bool result = true;

            return result;
        }

        [HttpGet]
        public List<Roulette> GetRoulette()
        {
            List<Roulette> result = new List<Roulette>();

            Roulette laR = new Roulette();

            laR.Id = 1;

            result.Add(laR);

            return result;
        }
    }
}
