using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        //Invocation metot demek.
        public override void Intercept(IInvocation invocation)
        {
            //Şablon oluşturuyoruz.
            //Transaction yönetimi projedeki tutarlılığı sağlar.
            //Örneğin bir hesaptan diğerine para gönderilmesi.
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();//Method içindeki bloğu komple çalıştırır.
                    transactionScope.Complete();
                }
                catch (System.Exception e)
                {
                    transactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}
