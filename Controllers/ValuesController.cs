using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace WebApplication1.Controllers
{
    
    public class ValuesController : Controller
    {
        /*public IActionResult Index()
        {
            return View();
        }*/

        [Route("/[controller]")]
        [Authorize]
        //[AllowAnonymous]
        [Route("getlogin")]
            public IActionResult GetLogin()
            {
                return Ok($"Ваш логин: {User.Identity.Name}");
            }

            [Authorize(Roles = "admin")]
            [Route("getrole")]
            public IActionResult GetRole()
            {
                return Ok("Ваша роль: администратор");
            }
        
    }
}