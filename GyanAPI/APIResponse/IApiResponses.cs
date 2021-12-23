using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GyanAPI.APIResponse
{
    public interface IApiResponses
    {
       IBaseApiResponse SuccessResponse(object data, string message);
       IBaseApiResponse BadRequestResponse(object data, string message);
       IBaseApiResponse NotFoundResponse(string message);
       IBaseApiResponse ServerError(string message);
    }
}
