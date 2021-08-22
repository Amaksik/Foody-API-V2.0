using Foody.BLL.Clients;
using Foody.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.BLL.Services
{
    public class DataService
    {
        IUnitOfWork Database;

        LogmealClient logmealClient;
        BarCodeClient barcodeClient;

        public DataService(IUnitOfWork uow)
        {
            Database = uow;

            logmealClient = new LogmealClient();
            barcodeClient = new BarCodeClient();
        }

        //meal recognition without proper user info
        public void Upload()
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




        //meal info by name
        [HttpGet("100g/{name}")]
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


        //info by barcode
        [HttpGet("barcode")]
        public async Task<IActionResult> BarcodeInfo([FromQuery] string barcode)
        {
            if (barcode != null)
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


        //consuming 
        [HttpPost("natural/{query}")]
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




    }
}
