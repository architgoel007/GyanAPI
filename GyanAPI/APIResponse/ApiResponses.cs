using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GyanAPI.APIResponse
{
    public class ApiResponses : IApiResponses
    {
        public IBaseApiResponse BaseApiResponse { get; }
        public ApiResponses(IBaseApiResponse baseApiResponse)
        {
            BaseApiResponse = baseApiResponse;
        }

        public IBaseApiResponse SuccessResponse(object data, string message)
        {
            BaseApiResponse.Code = HttpStatusCode.OK;
            BaseApiResponse.Data = data;
            BaseApiResponse.Message = message;
            BaseApiResponse.Status = Constant.HttpStatus.Success;
            return BaseApiResponse;
        }

       public IBaseApiResponse BadRequestResponse(object data, string message)
        {
            BaseApiResponse.Code = HttpStatusCode.BadRequest;
            BaseApiResponse.Data = data;
            BaseApiResponse.Message = message;
            BaseApiResponse.Status = Constant.HttpStatus.BadRequest;
            return BaseApiResponse;
        }

       public IBaseApiResponse NotFoundResponse(string message)
        {
            BaseApiResponse.Code = HttpStatusCode.NotFound;
            BaseApiResponse.Message = message;
            BaseApiResponse.Status = Constant.HttpStatus.NotFound;
            return BaseApiResponse;
        }

       public  IBaseApiResponse ServerError(string message)
        {
            BaseApiResponse.Code = HttpStatusCode.InternalServerError;
            BaseApiResponse.Message = message;
            BaseApiResponse.Status = Constant.HttpStatus.InternalServerError;
            return BaseApiResponse;
        }
    }
}
