using PlanerApp.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApp.Client.Services.Exceptions
{
    public class ApiException: Exception
    {
        public ApiErrorResponse ApiErrorResponse { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public ApiException(ApiErrorResponse _error,HttpStatusCode _statusCode):this(_error)
        { 
        
            StatusCode = _statusCode;
        }
        public ApiException(ApiErrorResponse _error)
        {
            ApiErrorResponse = _error;
            
        }

    }
}
