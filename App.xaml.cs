using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.Data;
using System.Windows;
using Taratra.Models;

namespace Taratra
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static IServiceProvider Services { get; private set; }

        public App(){
            var services =  new ServiceCollection();
            services.AddDbContext<TaratraDbContext>();

            // Services
           // services.AddScoped<IMatiereService, MatiereService>();

            // ViewModels
            //services.AddTransient<MatiereViewModel>();
            Services = services.BuildServiceProvider();

        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            using var db = new TaratraDbContext();
 
          
            db.Database.EnsureCreated();

        }

    }

}
