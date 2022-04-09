using Foody.BLL.Clients;
using Foody.BLL.DTO;
using Foody.DAL.Entities;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;



namespace Foody.BLL.Clients
{
    public class BarCodeClient : APIClient
    {
        private static string apiID;
      
        private static readonly string codeEndpoint = @"search/item?upc=";
        private static readonly string consumeEndpoint = @"natural/nutrients";

        public BarCodeClient(string BarcodeAPI_id, string BarcodeAPI_key)
        {
            httpClient = new HttpClient();
            APIUrl = @"https://trackapi.nutritionix.com/v2/";
            apiID = BarcodeAPI_id;
            Token = BarcodeAPI_key;

            httpClient.DefaultRequestHeaders.Add("x-app-id", apiID);
            httpClient.DefaultRequestHeaders.Add("x-app-key", Token);
        }


        public async Task<Food> GetBarcodeInfo(string barcode)
        {
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri(APIUrl + codeEndpoint + barcode);


            using (var response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                var body = await response.Content.ReadAsStringAsync();

                var foodlist = JsonSerializer.Deserialize<NutritionixResponse>(body);

                return foodlist.foods[0];

            } 

        }


        public async Task<Food> Get100gInfo(string name) 
        {
            string servings = $"100g of {name}";
            return await GetNaturalInfo(servings);

        }


        public async Task<Food> GetNaturalInfo(string query)
        {

            Query q = new Query(query);
            var json = JsonSerializer.Serialize(q);
            var data = new StringContent(json, Encoding.UTF8, "application/json");


            var response = await httpClient.PostAsync(APIUrl + consumeEndpoint, data);

            string result = await response.Content.ReadAsStringAsync();

            var responseitemslist = JsonSerializer.Deserialize<NutritionixResponse>(result);

            return responseitemslist.foods[0];
        }

    }
}
