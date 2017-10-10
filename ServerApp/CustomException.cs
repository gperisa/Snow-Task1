using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp
{
    public class CustomException : Exception
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public ExceptionType ExceptionType { get; set; }

        public CustomException(ExceptionType exceptionType, int errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            ExceptionType = exceptionType;
        }
    }

    public enum ExceptionType
    {
        FileError =1,
        ParsingError=2,
        FileWriteError=3
    }
}
