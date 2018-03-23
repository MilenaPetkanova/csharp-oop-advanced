using Logger.Models.Contracts;
using System;

namespace Logger.Models
{
    class Error : IError
    {
        public Error(DateTime dateTime, ErrorLevel level, string message)
        {
            this.DateTme = dateTime;
            this.Level = level;
            this.Message = message;
        }

        public DateTime DateTme { get; }

        public string Message { get; }

        public ErrorLevel Level { get; }
    }
}
