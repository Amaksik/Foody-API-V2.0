using Foody.DAL.Entities;
using Foody.DAL.Interfaces;
using Foody.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Foody.BLL
{
    public class UserService
    {
        IUnitOfWork Database;

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void MakeUser(User User)
        {
            
            // validation
            if (User.Id == null || User.Callories == 0)
                throw new ValidationException("Not enough info provided");
            
            
            // creating
            Database.Users.Create(User);
            Database.Save();
        }

        public IEnumerable<Product> GetFavourites(User User)
        {
            int id = Convert.ToInt32(User.Id);
            //validation
            if (Database.Users.Get(id) != null)
            {
                var result = Database.Users.Favourites(id);
                return result;
            }
            else { throw new EntryPointNotFoundException(); }
        }


        //getting user info by id
        public User GetUser(int user_id)
        {
            // validation
            if (user_id == 0)
            {
                throw new ValidationException("Id not provided");
            }
            else
            {// reading

                var user = Database.Users.Get(user_id);
                return user;
            }
        }



        ////adding users
        [HttpPost("adduser")]
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



        //Getting Statistics of user per days
        [HttpGet("{user_id}/statistics/{days}")]
        public async Task<IActionResult> GetStatistics(string user_id, int days)
        {
            if (user_id != null)
            {
                var findet = await _dbController.GetUserById(user_id);
                if (findet != null && findet.Favourite.Count > 0)
                {
                    List<DayIntake> result = new List<DayIntake>();

                    foreach (var item in findet.Statistics)
                    {
                        result.Add(item);
                    }
                    if (days > result.Count)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        List<DayIntake> resulttosend = new List<DayIntake>();
                        for (int i = 0; i < days; i++)
                        {
                            resulttosend.Add(result[0]);
                        }
                        return Ok(JsonSerializer.Serialize(resulttosend));

                    }


                }
                else if (findet != null && findet.Favourite.Count == 0)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound("user not found");
                }
            }
            else
            {
                return BadRequest("no id");
            }

        }



        //getting list of Favourite users products
        [HttpGet("{user_id}/favourite")]
        public async Task<IActionResult> Favourite(string user_id)
        {
            if (user_id != null)
            {
                var findet = await _dbController.GetUserById(user_id);
                if (findet != null && findet.Favourite.Count > 0)
                {
                    List<Product> result = new List<Product>();

                    foreach (var item in findet.Favourite)
                    {
                        result.Add(item);
                    }

                    return Ok(JsonSerializer.Serialize(result));
                }
                else if (findet != null && findet.Favourite.Count == 0)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound("user not found");
                }
            }
            else
            {
                return BadRequest("no id provided");
            }
        }




        //adding product to list of Favourite users products
        [HttpPut("{user_id}/addproduct")]
        public async Task<IActionResult> ProductAdd(string user_id, [FromBody] Product prdct)
        {
            if (user_id != null && prdct.Check())
            {
                await _dbController.AddProduct(user_id, prdct);
                return Ok("product has been added");
            }
            else
            {
                return BadRequest();
            }

        }


        //removing product from list of Favourite users products
        [HttpDelete("{user_id}/removeproduct")]
        public async Task<IActionResult> ProductRemove(string user_id, [FromBody] Product prdct)
        {
            if (user_id != null && prdct.Check())
            {
                await _dbController.RemoveProduct(user_id, prdct);
                return Ok("product has been added");
            }
            else
            {
                return BadRequest();
            }
        }



        //adding product to list of Favourite users products
        [HttpPost("{user_id}/consume")]
        public async Task<IActionResult> Consume(string user_id, [FromBody] Consume _new)
        {

            await _dbController.ConsumeProduct(user_id, _new.callories, DateTime.Today);
            return Ok("consumed");

        }







        //removing users
        [HttpDelete("{user_id}/removeuser")]
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


    }
}
