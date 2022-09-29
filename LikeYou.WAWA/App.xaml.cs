using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.DependencyInjection;
using Example;
using LikeYou.WAWA.Common;
using LikeYou.WAWA.Common.ICommon;
using Microsoft.Extensions.DependencyInjection;
using Serilog.Events;
using Serilog;
using DryIoc.ImTools;

namespace LikeYou.WAWA
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void  Application_Startup(object sender, StartupEventArgs e)
        {
            Application currApp = Application.Current;
            currApp.StartupUri = new Uri("MainWindow.xaml", UriKind.RelativeOrAbsolute);
            var basePath = AppContext.BaseDirectory;

            //services.AddControllersWithViews();
            var server = new ServiceCollection()
      
            .AddTransient<Windows.EditAddWindow>()     
             .AddTransient<Pages.Dialogs.AddUserControl>()
             .AddSingleton<Common.ICommon.ILogger,Logger>()
             .AddSingleton(new Appsettings(basePath)) ;
           
            
            Ioc.Default.ConfigureServices(server.BuildServiceProvider());


            const long defaultFileSizeLimitBytes = 1L * 1024 * 1024 * 20; // 10M

            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Async(c => c.File("Logs/logs.txt",
                rollingInterval: RollingInterval.Day,
                fileSizeLimitBytes: defaultFileSizeLimitBytes,
                rollOnFileSizeLimit: true))
            .CreateLogger();
            Log.Information("程序启动");
        }

    }
}
