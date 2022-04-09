using Foody.BLL.Clients;
using Foody.DAL.Interfaces;
using FoodyAPI.Clients;
using Microsoft.AspNetCore.Http;
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

        public DataService(IUnitOfWork uow, string barApiKey, string barApiToken, string Logmeal_bearer)
        {
            Database = uow;

            logmealClient = new LogmealClient(Logmeal_bearer);
            barcodeClient = new BarCodeClient(barApiKey, barApiToken);
        }

        //meal recognition without proper user info
        public void Upload(HttpRequest request)
        {

            var file = request.Form.Files[0];

            PhotoHandling ph = new PhotoHandling();

            var message = ph.FileUpload(file).Result;
            if (message != "notOk")
            {
                
            }
            else
            {
                throw new Exception("BadRequest");
            }


        }


        //meal info by name
        public async Task<bool> Get100gInfo(string name)
        {
            if (name != null)
            {

                try
                {
                    var result = await barcodeClient.Get100gInfo(name);
                    var _string = System.Text.Json.JsonSerializer.Serialize(result);
                    return true;
                }
                catch (Exception ex)
                {

                    throw new Exception( ex.Message + "\ncouldn't recognize it");
                }
            }
            else
            {
                throw new Exception("info not provided");
            }

        }


        //info by barcode
        public async Task<bool> BarcodeInfo(string barcode)
        {
            if (barcode != null)
            {
                var result = await barcodeClient.GetBarcodeInfo(barcode);
                var _string = System.Text.Json.JsonSerializer.Serialize(result);
                return true;

            }
            else
            {
                return false;
            }

        }


        //consuming 
        public async Task<bool> NaturalInfo(string query)
        {
            if (query != null)
            {
                try
                {
                    var result = await barcodeClient.GetNaturalInfo(query);
                    var _string = System.Text.Json.JsonSerializer.Serialize(result);
                    return true;
                }
                catch
                {throw new Exception("couldn't recognize it");}
            }
            else
            {throw new Exception("no info provided");}

        }




    }
}
