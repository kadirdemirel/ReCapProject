using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    public interface ICoreModule
    {
        //Bağımlılıklarımızı yükleyecek.
        void Load(IServiceCollection serviceCollection);
    }
}
