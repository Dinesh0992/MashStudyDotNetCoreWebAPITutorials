using System;
using System.Text.Json;

namespace MashStudyDotNetCoreWebAPITutorials.Errors
{
    public class ApiError
    {
        public ApiError(int ErrorCode,string ErrorMessage,string ErrorDetails=null)
        {
            this.ErrorCode=ErrorCode;
            this.ErrorMessage=ErrorMessage;
            this.ErrorDetails=ErrorDetails;
        }

        public int ErrorCode{get;set;}
        public string ErrorMessage{get;set;}

        public string ErrorDetails{get;set;}

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
