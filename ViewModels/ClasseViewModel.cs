using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Taratra.Models;
using Taratra.Services;
using Taratra.Services.Interfaces;
using Taratra.Views.Pages;

namespace Taratra.ViewModels
{
    public partial class ClasseViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Classe> classes;

        [ObservableProperty]
        private string classeName;

        [ObservableProperty]
        private int totalPages;
        [ObservableProperty]
        private int pageSize = 50;
        [ObservableProperty]
        private int currentPage =1;

        [ObservableProperty]
        private string messageError;

        [ObservableProperty]
        private Visibility isProgressBarVisible;

       

        public Action? CloseAddModalAction { get; set; }





        private TaratraDbContext _taratraDbContext;
        private IClasseService _classeService;




        public ClasseViewModel(TaratraDbContext taratraDbContext,IClasseService classeService)
        {
            _taratraDbContext = taratraDbContext;
            _classeService = classeService;
            ChargerClasse();
          
        }
        [RelayCommand]
        public async void ChargerClasse()
        {
            IsProgressBarVisible = Visibility.Visible;
           await Task.Delay(4000);
            var data = await _classeService.GetPaginatedAsync(CurrentPage,PageSize);
            TotalPages = data.TotalPages;
           
            Classes = new ObservableCollection<Classe>(data.Items);
            IsProgressBarVisible = Visibility.Hidden;
        }
        [RelayCommand]
        public void NextPagination()
        {
            if ((CurrentPage+1) > TotalPages) return;
            CurrentPage = CurrentPage + 1;
            ChargerClasse();

        }
        [RelayCommand]
        public void PreviousPagination()
        {
            if ((CurrentPage - 1 )<= 0) return;
            CurrentPage = CurrentPage - 1;
            ChargerClasse();
            
        }

        [RelayCommand]
        public void OpenAddModal()
        {
            var modal = new ClasseAddModal(this);
            // Ouvre la popup HandyControl
            Dialog d = Dialog.Show(modal);
            CloseAddModalAction = () => d.Close();

        }

        [RelayCommand]
        public void CloseModal()
        {
           CloseAddModalAction?.Invoke();

        }

        [RelayCommand]
        public async void AddClasse()
        {
            Classe classe= new Classe();
            classe.Nom = classeName;
            try
            {
                await _classeService.Add(classe);
                ChargerClasse();
                CloseAddModalAction?.Invoke();
            }
            catch (Exception ex) { 
                MessageError = ex.Message;
            }
        }
    }
}
