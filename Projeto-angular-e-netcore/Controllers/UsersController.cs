using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Projeto_angular_e_netcore.Controllers
{
    [ApiController, Authorize]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices userServices;

        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger, IUserServices userService)
        {
            this.userServices = userService; 
            this._logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.userServices.Get());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            return Ok(this.userServices.GetById(id));
        }


        [HttpPost]  
        public IActionResult Post(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(this.userServices.Post(userViewModel));
        }

        [HttpPut]
        public IActionResult Put(UserViewModel userViewModel) { 
            return Ok(this.userServices.Put(userViewModel));
     
        }

        [HttpDelete("{userId}")]
        public IActionResult Delete(string userId)
        {
            //string userId = TokenServices.GetValuewFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier);
            return Ok(this.userServices.Delete(userId));
        }

        [HttpPost("authenticate"), AllowAnonymous]
        public IActionResult Authenticate(UserAuthenticateRequestViewModel userViewModel)
        {
            return Ok(this.userServices.Authenticate(userViewModel));
        }
    }
}
