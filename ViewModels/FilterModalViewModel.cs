using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using Taratra.Models;

namespace Taratra.ViewModels;
public class FilterModalViewModel
{
    private readonly UserControl _view;
    public Action? CloseAction {  get; set; }

    public Dialog dialog { get;  set; }

    public ICommand CloseModalCommand { get; }
    public ICommand ApplyFilterCommand { get; }

    public ObservableCollection<Classe> Classes { get; set; }

    public FilterModalViewModel(UserControl view)
    {
        _view = view;

        CloseModalCommand = new RelayCommand(Close);
        ApplyFilterCommand = new RelayCommand(Apply);
        Classes = new ObservableCollection<Classe>
        {
            new Classe { Nom = "6ème" },
            new Classe { Nom = "5ème" },
            new Classe { Nom = "4ème" }
        };
    }

    private void Close()
    {
         if(CloseAction !=null) CloseAction.Invoke();
        
    }

    private void Apply()
    {
        // logiques des filtres

       
    }
}
