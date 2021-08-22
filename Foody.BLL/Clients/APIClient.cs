using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Foody.BLL.Clients
{
    public abstract class APIClient
    {
        public string APIUrl;

        public string Token;

        public HttpClient httpClient;

    }
}
