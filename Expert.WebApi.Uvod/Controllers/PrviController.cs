using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace Expert.WebApi.Uvod.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrviController : ControllerBase
    {
        public PrviController()
        {
        }

        [HttpGet("prvi")]
        public async Task<ActionResult<string>> Ping()
        {
            return "pong";
        }

        [HttpGet("drugi")]
        public async Task<ActionResult<string>> Pong()
        {
            return "ping";
        }

        [HttpGet("zbroji/prviBroj/{prviBroj}/drugiBroj/{drugiBroj}")]
        public async Task<ActionResult<int>> Zbroji(int prviBroj
            , int drugiBroj)
        {
            return prviBroj + drugiBroj;
        }

        [HttpGet("zbroji1/prviBroj/{prviBroj}/drugiBroj/{drugiBroj}")]
        public async Task<ActionResult<string>> Zbroji1(
            int drugiBroj, int? prviBroj = null)
        {
            if (prviBroj == null)
            {
                return "Niste upisali prvi broj";
            }
            return (prviBroj + drugiBroj).ToString();
        }

        [HttpGet("zbrojistringove/prvi/{prvi}/" +
            "drugi/{drugi}/tip/{tipConcat}")]
        public async Task<ActionResult<string>>
            ZbrojiString(string prvi, string drugi,
            int tipConcat)
        {
            //0 - klasično zbrajanje stringova
            //1 - upotrijebi concat
            //2 upotrijebi interpolaciju
            if (tipConcat == 0)
            {
                return prvi + " " + drugi;
            }
            else if (tipConcat == 1)
            {
                return string.Concat(prvi, " ", drugi);
            }
            else if (tipConcat == 2)
            {
                return $"prvi poslai string je: {prvi} a drugi poslani string je: {drugi}";
            }
            else
            {
                return "niste odabrali ispravan tip. Možete birati 0,1,2";
            }
        }

        [HttpGet]
        public async Task<ActionResult<string>> NazivFunkcije(string mozdaParam)
        {
            return mozdaParam;
        }
    }
}