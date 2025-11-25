using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Taratra.Models;
using Taratra.Services;
using Taratra.Services.Interfaces;

namespace Taratra.ViewModels
{
    public partial class ClasseViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Classe> classes;

        [ObservableProperty]
        private int totalPages;
        [ObservableProperty]
        private int pageSize = 50;
        [ObservableProperty]
        private int currentPage =1;

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
         
            var data = await _classeService.GetPaginatedAsync(CurrentPage,PageSize);
            TotalPages = data.TotalPages;
           
            Classes = new ObservableCollection<Classe>(data.Items);

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
    }
}
