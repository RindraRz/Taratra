using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using Taratra.Models;
using Taratra.Services; // si tu as un dossier Services
using Taratra.ViewModels;
using Taratra.Views;
using Taratra.Views.Pages;

namespace Taratra
{
    public partial class App : Application
    {
        public static IServiceProvider Services { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var serviceCollection = new ServiceCollection();

            ConfigureServices(serviceCollection);

            Services = serviceCollection.BuildServiceProvider();

            // Créer la base si nécessaire
            using (var scope = Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TaratraDbContext>();
                db.Database.EnsureCreated();
            }

            // Démarrer l'app
            var mainWindow = Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // EF Core
            services.AddDbContext<TaratraDbContext>();

            // Services métier
            services.AddScoped<SystemeConfigService>();
            // services.AddScoped<IEleveService, EleveService>(); // exemple pour interface

            // ViewModels
            services.AddSingleton<MainViewModel>();

            // Windows
            services.AddSingleton<MainWindow>();
        }
    }
}
