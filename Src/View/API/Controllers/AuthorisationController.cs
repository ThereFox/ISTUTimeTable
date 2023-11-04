using System.IO;
using System.Security.AccessControl;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using ISTUTimeTable.Entitys;
using HotChocolate.Authorization;

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