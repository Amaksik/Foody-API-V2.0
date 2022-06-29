using System.ComponentModel.DataAnnotations;

namespace Foody.BLL.Services
{
    public class RecognitionServiceOptions
    {
        public const string Tokens = "Tokens";

        [Required]
        public string BarcodeApiKey { get; set; }
        [Required]
        public string BarcodeApiToken { get; set; }
        [Required]
        public string LogmealApiBearer { get; set; }
    }
    
}