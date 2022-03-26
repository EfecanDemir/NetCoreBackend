using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    // methodu nasil yorumlayacagi anlatilir
    public abstract class MethodInterception:MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { } // metot baslangicinda calisir
        protected virtual void OnAfter(IInvocation invocation) { }  // metot sonunda calisir
        protected virtual void OnException(IInvocation invocation,Exception e) { } // Hatali olursa calisir
        protected virtual void OnSuccess(IInvocation invocation) { } // Basarili oldugunda calisir
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed(); // operasyonu calistir
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e); // hata firlat
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }
}
