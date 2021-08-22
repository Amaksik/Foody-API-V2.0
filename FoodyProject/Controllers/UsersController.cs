using Foody.BLL;
using Foody.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodyProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        UserService userService;
        DataService dataService;

        public UsersController(UserService usService, DataService dtService)
        {
            userService = usService;
            dataService = dtService;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                var user = userService.GetUser(id);
                return Ok(user);
            }
            catch (Exception)
            {

                return NotFound();
            }
            
        }






    }



}
