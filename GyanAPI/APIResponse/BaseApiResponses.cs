using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GyanAPI.APIResponse
{
    public class BaseApiResponses : IBaseApiResponse
    {
        public string Status { get; set; }
        public HttpStatusCode Code { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}
