using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FoodyAPI.Models
{
    public class PhotoResponse
    {
        public int imageId { get; set; }
        public List<RecognitionResult> recognition_results { get; set; }
        public class RecognitionResult
        {
            public int id { get; set; }
            public string name { get; set; }
            public double prob { get; set; }
            public List<object> subclasses { get; set; }
        }

    }
    public class Photo
    {
        public Photo() { }
        public Image image { get; set; }
        public static async Task<PhotoResponse> SendRequest(Image img)
        {
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.logmeal.es/v2/recognition/dish/v0.8?skip_types=%5B1%2C3%5D&language=eng");
                var requestContent = new MultipartFormDataContent();

                //ImageConverter Class convert Image object to Byte array.
                byte[] bytes = (byte[])new System.Drawing.ImageConverter().ConvertTo(img, typeof(byte[]));

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




    }
}
