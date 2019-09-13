using Azure.Utils;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Services
{
    public interface IAzureAppService
    {
        [Get("/persongroups?top=1000&returnRecognitionModel=false")]
        Task<HttpResponseMessage> GetGroups([Header(Config.NameAzureKey)] string key);
    }
}
