using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddtoBasketAPI.Model
{
    public class ApiResults<T>
    {
        public bool IsSuccess { get; protected set; }

        public string Message { get; protected set; }
        public T Response { get; protected set; }

        public ApiResults(T response, bool isSuccess = true, string message = null)
        {
            Response = response;
            IsSuccess = isSuccess;
            Message = message;
        }

        public ApiResults(T response, List<string> messages, bool isSuccess = false)
        {

            Response = response;
            IsSuccess = isSuccess;
            Message = string.Join(Environment.NewLine, messages);
        }

    }
}
