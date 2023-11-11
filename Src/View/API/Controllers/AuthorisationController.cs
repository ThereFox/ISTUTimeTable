using Microsoft.AspNetCore.Mvc;
using ISTUTimeTable.Entitys;

namespace ISTUTimeTable.Controllers
{
    [ApiController]
    [Route("auth/")]
    public class AuthorisationController : ControllerBase
    {
        [HttpPost]
        [Route("/")]
        public async Task<IActionResult> Authorise()
        {
            if(await CanAuthorise() == false)
            {
                return BadRequest("404");
            }
            User userInfo = await GetUserInfo();
            return Ok();
        }

        [HttpPost]
        [Route("/createUser")]
        public void CreateAccount(){}

        private async Task<bool> CanAuthorise()
        {
            await Task.CompletedTask;
            return true;
        }
        private async Task<User> GetUserInfo()
        {
            await Task.CompletedTask;
            return null;
        }
        private void Authorise(User user)
        {

        }
    }
}