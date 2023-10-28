using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace ISTUTimeTable.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorisationController : ControllerBase
    {
        [HttpPost]
        public IActionResult Authorise()
        {
            if(Request.HasJsonContentType() == false)
            {
                return new JsonResult(new Exception("tets"));
            }
            return new NoContentResult();
        }
    }
}