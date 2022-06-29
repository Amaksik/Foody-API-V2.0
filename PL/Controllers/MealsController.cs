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
using FoodyAPI.Clients;
using FoodyAPI.Data;
using System.Text.Json;

namespace FoodyAPI.Controllers
{
    [ApiController]
    [Route("api")]

    public class MealsController : Controller
    {
        private static DbController _dbController;
        public MealsController(DbController dbController)
        {
            _dbController = dbController;
        }


        //meal recognition without proper user info
        [HttpPost("meal/recognize")]
        public IActionResult Upload()
        {
            PhotoHandling ph = new PhotoHandling();
            try
            {
                var file = Request.Form.Files[0];

                var message = ph.FileUpload(file).Result;
                if (message != "notOk")
                {
                    return Ok(message);
                }
                else
                {
                    return BadRequest();
                }
                
                

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }


        }


        //meal info by name
        [HttpGet("meal/100g/{name}")]
        public async Task<IActionResult> Consume100Info([FromQuery] string name)
        {
            if (name != null)
            {
                var client = new BarCodeClient();
                try
                {
                    var result = await client.Consume100Info(name);
                    var _string = System.Text.Json.JsonSerializer.Serialize(result);
                    return Ok(_string);
                }
                catch (Exception)
                {

                    return BadRequest("couldn't recognize it");
                }
            }
            else
            {
                return BadRequest("info not provided");
            }

        }


        //consuming 
        [HttpPost("meal/natural/{query}")]
        public async Task<IActionResult> NaturalInfo(string query)
        {
            if (query != null)
            {
                var client = new BarCodeClient();
                try
                {
                    var result = await client.GetNaturalInfo(query);
                    var _string = System.Text.Json.JsonSerializer.Serialize(result);
                    return Ok(_string);
                }
                catch
                {

                    return BadRequest("couldn't recognize it");
                }
                
                

            }
            else
            {
                return BadRequest("no info provided");
            }

        }



        //info by barcode
        [HttpGet("meal/barcode")]
        public async Task<IActionResult> BarcodeInfo([FromQuery] string barcode)
        {
            if (barcode  != null)
            {
                var client = new BarCodeClient();
                var result = await client.GetBarcodeInfo(barcode);
                var _string = System.Text.Json.JsonSerializer.Serialize(result);
                return Ok(_string);
               
            }
            else
            {
                return BadRequest("barcode not provided");
            }

        }

    }
}