using System;
using MailSender1.lib.Interfaces;
using MailSender1.lib.Service;
using MailSender1.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MailSender1
{
    public partial class App 
    {
        private static IHost _Hosting;

        public static IHost Hosting => _Hosting
              ??= Host.CreateDefaultBuilder(Environment.GetCommandLineArgs())
              .ConfigureServices(ConfigureServices)
              .Build();

        public static IServiceProvider Service => Hosting.Services;

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
            services.AddTransient<IMailService, SmtpMailService>();

        }
    }
}
