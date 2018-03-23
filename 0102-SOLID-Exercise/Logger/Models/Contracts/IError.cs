using System;

namespace Logger.Models.Contracts
{
    public interface IError : ILevelable
    {
        DateTime DateTme { get; }

        string Message { get; }
    }
}

