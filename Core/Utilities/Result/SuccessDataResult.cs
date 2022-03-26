using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        // hem data hem true hemde mesaj
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {

        }
        // hem data hem true
        public SuccessDataResult(T data) : base(data, true)
        {

        }
        // data default ,mesaj,success
        public SuccessDataResult(string message) : base(default, true, message)
        {

        }
        // data default sadece success
        public SuccessDataResult() : base(default, true)
        {

        }
    }
}
