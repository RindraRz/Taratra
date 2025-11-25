using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using Taratra.ViewModels;

namespace Taratra.Views
{
    public partial class ConfigWindow : Window
    {
        public ConfigWindow(ConfigWindowViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;

            // On assigne l'action qui sera appelée depuis le ViewModel
            viewModel.CloseAction = () =>
            {
                var mainWindow = App.Services.GetRequiredService<MainWindow>();
                // S'assurer que MainWindow est l'application "MainWindow" pour éviter la fermeture de l'application
                Application.Current.MainWindow = mainWindow;
                mainWindow.Show();
                this.Close();
               
            };
          

        }
    }
}
