using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Projeto_angular_e_netcore.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices userServices;

        private readonly ILogger<WeatherForecastController> _logger;

        public UsersController(ILogger<WeatherForecastController> logger, IUserServices userService)
        {
            this.userServices = userService; 
            this._logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            this.userServices.Test();
            return Ok("Ok");
        }
    }
}
