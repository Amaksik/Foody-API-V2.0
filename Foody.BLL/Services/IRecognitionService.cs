using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Foody.BLL.Services
{
    public interface IRecognitionService
    {
        Task<bool> BarcodeInfo(string barcode);
        Task<bool> Get100gInfo(string name);
        Task<bool> NaturalInfo(string query);
        void Upload(HttpRequest request);
    }
}