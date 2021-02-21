using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    //Asıl olayın meydana geldiği yer tam burası.
    //Burası bizim methodlarımızın ana çatısı diyebileceğimiz kısım.
    //Attributelerin nerede çalıştıralacağını gösterdiğimiz ana çatı.
    //Aşağıda da görüldüğü gibi 4 virtual fonksiyonumuzun içi boş.
    //Bunun sebebi ise bu sınıfdan kalıtım alan ValidationAspect sınıfımızda kod ezme işlemi yapmak.
    //Kod ezme işlemi yapdığımızda (Virtual-Override) yapıldığında methodun içini istediğimiz gibi doldurabiliriz.
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);//Methodlarımızın başında çalıştırmak istersek.
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);//Methodlarımız hata aldığında çalıştırmak istersek.
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);//Methodlarımız hata alsın yada almasın çalıştırmak istersek.
                }
            }
            OnAfter(invocation);//Methodlarımızın sonunda çalıştırmak istersek.
        }
    }
}
