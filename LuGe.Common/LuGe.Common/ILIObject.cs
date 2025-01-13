using System;
namespace LISystem2
{
    interface ILIObject
    {
        string ErrorMsg { get; }
        bool IsError { get; }
    }
}
