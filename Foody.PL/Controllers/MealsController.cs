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
using System.Text.Json;
using Foody.BLL.Services;

namespace Foody.PL.Controllers
{
    [ApiController]
    [Route("api")]

    public class MealsController : Controller
    {
        private static IDataService _dataService;
        public MealsController(IDataService dataService)
        {
            _dataService = dataService;
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
                
                try
                {
                    var result = await _dataService.Get100gInfo(name);
                    return Ok(result);
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
                try
                {
                    var result = _dataService.NaturalInfo(query);
                    return Ok(result);
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
                var result = _dataService.BarcodeInfo(barcode);
                return Ok(result);
               
            }
            else
            {
                return BadRequest("barcode not provided");
            }

        }

    }
}