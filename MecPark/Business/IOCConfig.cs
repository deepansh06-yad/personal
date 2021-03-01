using Business.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public static class IOCConfig
    {
        public static void ConfigureServices(ref IServiceCollection services)
        {
            Entities.IOCConfig.ConfigureServices(ref services);
            services.AddScoped<IUserManager, UserManager>();
            
        }
    }
}
