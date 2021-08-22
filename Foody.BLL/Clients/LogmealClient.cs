using FoodyAPI.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;


namespace Foody.BLL.Clients
{

    public class LogmealClient : APIClient
    {


        public LogmealClient()
        {
            httpClient.BaseAddress = new Uri("https://api.logmeal.es/v2/recognition/dish/v0.8?skip_types=%5B1%2C3%5D&language=eng");
            httpClient.DefaultRequestHeaders.Authorization =
                 new AuthenticationHeaderValue("Bearer", Constants.Logmeal_bearer);
        }


        public async Task<PhotoResponse> SendRequest(Image img)
        {

            var requestContent = new MultipartFormDataContent();


            //ImageConverter Class convert Image object to Byte array.
            byte[] bytes = (byte[])(new ImageConverter()).ConvertTo(img, typeof(byte[]));

            var imageContent = new ByteArrayContent(bytes);
            imageContent.Headers.ContentType =
                MediaTypeHeaderValue.Parse("image/jpeg");


            requestContent.Add(imageContent, "image", "image.jpeg");

            var result = await httpClient.PostAsync("https://api.logmeal.es/v2/recognition/dish/v0.8?skip_types=%5B1%2C3%5D&language=eng", requestContent);
            string resultContent = await result.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<PhotoResponse>(resultContent);
        }


        public async Task<string> FileUpload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return "NotOk";
            }

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                using (var img = Image.FromStream(memoryStream))
                {

                    PhotoResponse resend = new PhotoResponse();
                    resend = await SendRequest(img);
                    try
                    {
                        var answer = resend.recognition_results[0].name;
                        return answer;

                    }
                    catch
                    {
                        return "productNotFound";
                    } 
                }
            }
        }
    }
}
