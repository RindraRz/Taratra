using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls;
using System.Windows;
using System.Windows.Input;
using Taratra.Views.Pages;

namespace Taratra.ViewModels;
public partial class BulletinPageViewModel : ObservableObject
{
   
    public BulletinPageViewModel()
    {
       
    }

    [RelayCommand]
    private void OpenFilter()
    {
        var modal = new FilterModalUC();
        var vm = new FilterModalViewModel(modal);

        modal.DataContext = vm;

        // Ouvre la popup HandyControl
        Dialog d =Dialog.Show(modal);

        //vm.dialog =d;
        vm.CloseAction = () => d.Close();
       
        
    }
}
