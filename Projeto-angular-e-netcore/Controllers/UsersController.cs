using Application.Interfaces;
using Application.ViewModels;
using Auth.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Projeto_angular_e_netcore.Controllers
{
    [ApiController, Authorize]
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

        [HttpGet, AllowAnonymous]
        public IActionResult Get()
        {
            return Ok(this.userServices.Get());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            return Ok(this.userServices.GetById(id));
        }


        [HttpPost, AllowAnonymous]  
        public IActionResult Post(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(this.userServices.Post(userViewModel));
        }

        [HttpPut, AllowAnonymous]
        public IActionResult Put(UserViewModel userViewModel) { 
            return Ok(this.userServices.Put(userViewModel));
     
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            string userId = TokenServices.GetValuewFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier);
            return Ok(this.userServices.Delete(userId));
        }

        [HttpPost("authenticate"), AllowAnonymous]
        public IActionResult Authenticate(UserAuthenticateRequestViewModel userViewModel)
        {
            return Ok(this.userServices.Authenticate(userViewModel));
        }
    }
}
