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
using LikeYou.WAWA.EX;
using DryIoc;
using LikeYou.WAWA.VIewModels;
using HanumanInstitute.MvvmDialogs.Wpf;
using DialogService = HanumanInstitute.MvvmDialogs.Wpf.DialogService;
using HanumanInstitute.MvvmDialogs;

namespace LikeYou.WAWA
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {    
            ConfigureServices();
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
     
            this.InitializeComponent();
        }



        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Application currApp = Application.Current;
            currApp.StartupUri = new Uri("MainWindow.xaml", UriKind.RelativeOrAbsolute);
        }

        /// <summary>
        /// Gets the current <see cref="App"/> instance in use
        /// </summary>
        public new static App Current => (App)Application.Current;

        /// <summary>
        /// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
        /// </summary>
        public IServiceProvider Services { get; }

        /// <summary>
        /// Configures the services for the application.
        /// </summary>
        private static void ConfigureServices()
        {
            var basePath = AppContext.BaseDirectory;
            var services = new ServiceCollection();


            services
           
            .AddSingleton<Common.ICommon.ILogger, Logger>()
              .AddSingleton<IDialogService>(new DialogService(
                    new DialogManager(viewLocator: new ViewLocator()),
                    viewModelFactory: x => Ioc.Default.GetService(x)))
            //.AddSingleton<IDialogService, DialogService>()
             .AddTransient<Pages.Dialogs.AddUserControl>()
            .AddTransient<UserViewModel>()
              .AddTransient<RoleViewModel>()
                .AddTransient<LogInfoViewModel>()
             .AddTransient<EditAddWindowViewModel>()
              .AddTransient<EditRoleWindowViewModel>()
            .AddSingleton(new Appsettings(basePath));

   
            Ioc.Default.ConfigureServices(services.BuildServiceProvider());
        }

     

    }
}
