using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodyAPI.Models;
using System.Drawing;
using FoodyAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;
using FoodyAPI.Data;

namespace FoodyAPI.Controllers
{
    [ApiController]
    [Route("api")]

    public class FoodyController : Controller
    {
        private static DbController _dbController;
        public FoodyController(DbController dbController)
        {
            _dbController = dbController;
        }


        //meal recognition without proper user info
        [HttpPost("recognize")]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                return FileUpload(file).Result;
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }



        [HttpPost("adduser")]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            if (user.id != null && user.callories >= 300 )
            {

                var findet = _dbController.GetUserById(user.id);
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
        [HttpGet("removeuser/{user_id}")]
        public IActionResult RemoveUser(string user_id)

        {
            if (allusers.IsInside(user_id) == true)
            {
                allusers.Remove(allusers.ReturnUser(user_id));
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }


        //getting user info by id
        [HttpGet("{user_id}")]
        public IActionResult GetUser(string user_id)
        {
            if (allusers.IsInside(user_id))
            {
                return Ok(allusers.ReturnUser(user_id));
            }
            else
            {
                return NotFound();
            }

        }


        //getting list of Favourite users products
        [HttpGet("{user_id}/products")]
        public IEnumerable<Product> Favourite(string user_id)
        {
            User user = allusers.ReturnUser(user_id);
            List<Product> result = new List<Product>();
            foreach (Product pr in user.Favourite)
            {
                result.Add(pr);
            }
            return result;
        }

        //adding product to list of Favourite users products
        [HttpPost("{user_id}/addproduct")]
        public IActionResult ProductAdd(string user_id, [FromBody] Product prdct)
        {
            allusers.AddProduct(allusers.ReturnUser(user_id), prdct);
            return Ok();
        }


        //removing product to list of Favourite users products
        [HttpDelete("{user_id}/removeproduct")]
        public IActionResult ProductRemove(string user_id, [FromBody] Product prdct)
        {
            User user = allusers.ReturnUser(user_id);
            user.RemoveProduct(prdct);

            return Ok();
        }


        public async Task<PhotoResponse> SendRequest(string path)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.logmeal.es/v2/recognition/dish/v0.8?skip_types=%5B1%2C3%5D&language=eng");
                var requestContent = new MultipartFormDataContent();
                //    here you can specify boundary if you need---^
                //Read Image File into Image object.
                Image img = Image.FromFile(path);

                //ImageConverter Class convert Image object to Byte array.
                byte[] bytes = (byte[])(new ImageConverter()).ConvertTo(img, typeof(byte[]));

                var imageContent = new ByteArrayContent(bytes);
                imageContent.Headers.ContentType =
                    MediaTypeHeaderValue.Parse("image/jpeg");

                client.DefaultRequestHeaders.Authorization =
                 new AuthenticationHeaderValue("Bearer", "a191bc0b178170db39a22225f5ba87d8e441641b");


                requestContent.Add(imageContent, "image", "image.jpeg");
                var result = await client.PostAsync("https://api.logmeal.es/v2/recognition/dish/v0.8?skip_types=%5B1%2C3%5D&language=eng", requestContent);
                string resultContent = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<PhotoResponse>(resultContent);
            };
        }

        public async Task<PhotoResponse> SendRequest(Image img)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.logmeal.es/v2/recognition/dish/v0.8?skip_types=%5B1%2C3%5D&language=eng");
                var requestContent = new MultipartFormDataContent();


                //ImageConverter Class convert Image object to Byte array.
                byte[] bytes = (byte[])(new ImageConverter()).ConvertTo(img, typeof(byte[]));

                var imageContent = new ByteArrayContent(bytes);
                imageContent.Headers.ContentType =
                    MediaTypeHeaderValue.Parse("image/jpeg");

                client.DefaultRequestHeaders.Authorization =
                 new AuthenticationHeaderValue("Bearer", "a191bc0b178170db39a22225f5ba87d8e441641b");


                requestContent.Add(imageContent, "image", "image.jpeg");

                var result = await client.PostAsync("https://api.logmeal.es/v2/recognition/dish/v0.8?skip_types=%5B1%2C3%5D&language=eng", requestContent);
                string resultContent = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<PhotoResponse>(resultContent);
            };
        }

        public async Task<IActionResult> FileUpload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest();
            }

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                using (var img = Image.FromStream(memoryStream))
                {

                    PhotoResponse resend = new PhotoResponse();

                    resend = SendRequest(img).Result;
                    return Ok(($"'imageId': {resend.imageId},'recognition_results': ['id': '{resend.recognition_results[0].id}','name': '{resend.recognition_results[0].name}'"));
                }
            }
        }

    }
}
