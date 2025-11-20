using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Controls;
using Taratra.Services;
using Taratra.Models ;

namespace Taratra.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private UserControl currentPage;
        
        private readonly SystemeConfigService _systemeConfigService;

        public MainViewModel(SystemeConfigService systemeConfigService)
        {
            _systemeConfigService = systemeConfigService;
            // Page par défaut
            currentPage = new Views.Pages.ElevesPage();

            List<TypeEvaluation> typeEvaluations = new List<TypeEvaluation>
            {
               new TypeEvaluation  { Nom = "Controle 1 " , Ordre=1},
               new TypeEvaluation  { Nom = "Controle 2 " , Ordre=2},
               new TypeEvaluation  { Nom = "EXAM" , Ordre=3},
            };
            SystemeConfig config = new SystemeConfig { Evaluations = typeEvaluations};

            _systemeConfigService.SaveSystemeConfig(config);
        }

        [RelayCommand]
        private void NavigateEleves()
        {
            CurrentPage = new Views.Pages.ElevesPage();
        }

        [RelayCommand]
        private void NavigateBulletins()
        {
           CurrentPage = new Views.Pages.BulletinPage();
        }

        //[RelayCommand]
        //private void NavigateNotes()
        //{
        //    CurrentPage = new Views.Pages.NotesPage();
        //}
    }
}
