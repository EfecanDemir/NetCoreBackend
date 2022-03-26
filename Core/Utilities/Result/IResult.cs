using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
    // Void ile yazilan islemler icin 
    public interface IResult
    {
        //set etmeme sebebimiz newleme yapmamak
        //kullanicinin kafasina gore mesaj girmesini engellemek
        bool Success { get; }
        string Message { get; }
    }
}
