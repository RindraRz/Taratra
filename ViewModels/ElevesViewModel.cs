using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Taratra.Models;

namespace Taratra.ViewModels
{
    public partial class ElevesViewModel : ObservableObject
    {
        public ObservableCollection<Eleve> Eleves { get; set; }

        public ElevesViewModel()
        {
            Eleves = new ObservableCollection<Eleve>
            {
                new Eleve { Nom="RAZAFINDRAKOTO", Prenom="Rindraniaina", Classe="Terminale D" },
                new Eleve { Nom="RANDRIAMAMPIONONA", Prenom="Miora", Classe="Première C" }
            };
        }
    }
}
