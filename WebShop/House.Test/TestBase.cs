﻿using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Spaceship.Test.Macros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.ServiceInterface;
using WebShop.Data;
using WebShop.ApplicationServices.Services;

namespace House.Test
{
    public abstract class TestBase : IDisposable
    {
        protected IServiceProvider serviceProvider { get; }
        protected TestBase()
        {
            var services = new ServiceCollection();
            SetupServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        public void Dispose()
        {

        }

        protected T Svc<T>()
        {
            return serviceProvider.GetService<T>();
        }
        protected T Macro<T>() where T : IMacro
        {
            return serviceProvider.GetService<T>();
        }

        public virtual void SetupServices(IServiceCollection services)
        {


            //var config = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            //services.AddLogging(options =>
            //{
            //    options.AddConfiguration(config.GetSection("Logging"));
            //    options.AddConsole();
            //    options.AddDebug();
            //});

            services.AddScoped<IHouseService, HouseService>();

            services.AddDbContext<WebShopDbContext>(x =>
            {
                x.UseInMemoryDatabase("TEST");
                x.ConfigureWarnings(e => e.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            });

            RegisterMacros(services);
        }

        private void RegisterMacros(IServiceCollection services)
        {
            var macroBaseType = typeof(IMacro);

            var macros = macroBaseType.Assembly.GetTypes()
                .Where(x => macroBaseType.IsAssignableFrom(x) && !x.IsInterface
                && !x.IsAbstract);

            foreach (var macro in macros)
            {
                services.AddTransient(macro);
            }
        }

    }
}
