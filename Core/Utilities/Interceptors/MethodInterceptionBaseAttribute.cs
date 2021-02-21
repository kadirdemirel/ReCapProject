using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Interceptors
{
    //Burası ise başlangıç diyebileceğimiz kısım.
    //Sınıf veya method'lara Attribute ekleyebiliriz birden fazla Attribute kullanılabiliriz, Inherited edilen bir yerde kullanabiliriz.
    //Birden fazladan kasıt Loglama işlemini düşünecek olursak farklı parametreler kullanarak 2 farklı yerde kullanılabilir.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        //Öncelik vermek için oluşturduğumuz property.
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
