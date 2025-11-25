using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Controls;
using Taratra.Services;
using Taratra.Models ;
using Taratra.Views;
using Taratra.Views.Pages;

namespace Taratra.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private UserControl currentPage;

        private ClassesPage classesPage;
        
       
        public MainViewModel(ClassesPage pageClasse)
        {
           
            classesPage = pageClasse;
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

        [RelayCommand]
        private void NavigateClasses()
        {
            CurrentPage = classesPage;
        }
    }
}
