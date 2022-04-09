using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodyAPI.Models;
using System.Drawing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;

namespace Foody.PL.Controllers
{
    [ApiController]
    [Route("api")]

    public class UsersController : Controller
    {
        private static DbController _dbController;
        public UsersController(DbController dbController)
        {
            _dbController = dbController;
        }


        [HttpGet("users")]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var result = await _dbController.GetAllUsers() ;
            return result;
        }


        //getting user info by id
        [HttpGet("users/{user_id}")]
        public async Task<IActionResult> GetUser(string user_id)
        {
            if (user_id != null)
            {
                var findet = await _dbController.GetUserById(user_id);
                if (findet != null)
                {
                    return Ok(JsonSerializer.Serialize(findet));
                }
                else
                {
                    return NotFound("user not found");
                }
            }
            else
            {
                return BadRequest("id not provided");
            }

        }

        ////adding users
        [HttpPost("users")]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            if (user.ID != null && user.callories >= 300)
            {

                var findet = await _dbController.GetUserById(user.ID);
                if (findet == null)
                {

                    var result = await _dbController.AddUser(user);
                    return Ok("user has been added");
                }
                else
                {
                    return BadRequest("user already exist");
                }

            }
            else
            {
                return BadRequest("not enough info");
            }
        }

        //removing users
        [HttpDelete("users/{user_id}")]
        public async Task<IActionResult> RemoveUser(string user_id)
        {
            if (user_id != null)
            {
                var findet = await _dbController.GetUserById(user_id);
                if (findet != null)
                {
                    await _dbController.RemoveUser(user_id);
                    return Ok("user has been removed");
                }
                else
                {
                    return NotFound("user not found");
                }
            }
            else
            {
                return BadRequest("id not provided");
            }

        }



        //adding info about eaten product
        [HttpPost("users/{user_id}/consume")]
        public async Task<IActionResult> Consume(string user_id, [FromBody] Consume _new)
        {

            await _dbController.ConsumeProduct(user_id, _new.callories, DateTime.Today);
            return Ok("consumed");

        }



    }
}