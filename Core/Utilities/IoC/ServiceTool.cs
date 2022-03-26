using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.IoC
{
    public static class ServiceTool
    {
        //.net servislerini alir build eder
        // bu kod web apideki autofacde olusturulan injectionlari olusturmaya yarar
        // bu tool ile istenilen herhangi bir interface'in service deki karsiligi alinir
        public static IServiceProvider ServiceProvider { get; private set; }
        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
