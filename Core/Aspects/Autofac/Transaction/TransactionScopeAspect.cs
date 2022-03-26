using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;

namespace Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        // transaction olayinda Interceptin ezilmesi gerekir

        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed(); // basarili mi?
                    transactionScope.Complete();// basarili ise calistir
                }
                catch (Exception e)
                {
                    transactionScope.Dispose();// yapilan islemleri geri al
                    throw;
                }
            }
        }
    }
}
