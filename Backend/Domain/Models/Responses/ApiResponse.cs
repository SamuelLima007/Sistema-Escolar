using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Domain.Models
{
    public class ApiResponse<T>
    {
        public bool Result { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; } = new List<string>();


        public ApiResponse(bool _result, string _message, T _data)
        {
            Result = _result;
            Message = _message;
            Data = _data;

        }

        public ApiResponse(bool _result, string _message)
        {
            Result = _result;
            Message = _message;

        }

        public ApiResponse(string _message, T _data)
        {
            Message = _message;
            Data = _data;

        }

        public ApiResponse(string _message)
        {
            Message = _message;
        }

        public ApiResponse(string _message, string Error)
        {
            Message = _message;
            Errors.Add(Error);
        }




    }
}