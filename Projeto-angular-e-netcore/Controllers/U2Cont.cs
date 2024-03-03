using Microsoft.AspNetCore.Mvc;

namespace Projeto_angular_e_netcore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class U2Cont : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "";
            //return Ok("Ok");
        }
    }
}
