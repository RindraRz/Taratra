using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Controls;

namespace Taratra.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private UserControl currentPage;

        public MainViewModel()
        {
            // Page par défaut
            currentPage = new Views.Pages.ElevesPage();
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
