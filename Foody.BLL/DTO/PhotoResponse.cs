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
        }

    }
    
    
    public class Photo
    {
        public Photo() { }
        public Image image { get; set; }
        
    }
}
