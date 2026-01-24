using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Models;
using ProjetoNotas.Domain.Models;

namespace Backend.Domain.Extensions
{
    public static class ResponseApiExtension <T>
    {

        public static ApiResponse<T> CreateApiResponseFail(ApiResponse<T> api)
        {
            api.Result = false;
            return api;
        }

        
        public static ApiResponse<T> CreateApiResponseSucess(ApiResponse<T> api)
        {
           api.Result = true;
            return api;
        }
       
}
}