using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using Taratra.Models;
using Taratra.Services; // si tu as un dossier Services
using Taratra.Services.Interfaces;
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

            using (var scope = Services.CreateScope())
            {
                var systemeConfigService = scope.ServiceProvider.GetRequiredService<ISystemeConfigService>();

                if (!systemeConfigService.IsConfigured())
                {
                    var configViewModel = scope.ServiceProvider.GetRequiredService<ConfigWindowViewModel>();
                    var configWindow = new ConfigWindow(configViewModel);

                    bool? result = configWindow.ShowDialog(); // Bloque ici jusqu'à fermeture de ConfigWindow

                    
                }
            }

            // Après avoir fermé ConfigWindow, ouvrir MainWindow
            var mainWindow = Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }



        private void ConfigureServices(IServiceCollection services)
        {
            // EF Core
            services.AddDbContext<TaratraDbContext>();

            // Services métier
            services.AddScoped<ISystemeConfigService,SystemeConfigService>();
            services.AddScoped<IClasseService, ClasseService>();
            services.AddScoped<IMatiereService, MatiereService>();
            services.AddScoped<ISystemeEvaluationService, SystemeEvaluationService>();


            // services.AddScoped<IEleveService, EleveService>(); // exemple pour interface

            // ViewModels
            services.AddSingleton<MainViewModel>();
            services.AddScoped<ConfigWindowViewModel>();
            services.AddScoped<ClasseViewModel>();

            // Windows
            services.AddScoped<ClasseAddModal>();
            services.AddSingleton<ClassesPage>();
            services.AddSingleton<MainWindow>();
        }
    }
}
