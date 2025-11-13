using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using Taratra.Models;

namespace Taratra.ViewModels
{
    public partial class ElevesViewModel : ObservableObject
    {
      

        [ObservableProperty]
        private ObservableCollection<Eleve> eleves;

        public ElevesViewModel()
        {
            ChargerEleves();
        }

        [RelayCommand]
        public void ChargerEleves()
        {
            using var db = new TaratraDbContext();
            var data = db.Eleves.AsNoTracking().OrderBy(e => e.Nom).ToList();
            Eleves = new ObservableCollection<Eleve>(data);
        }

        [RelayCommand]
        public void AjouterEleve()
        {
            using var db = new TaratraDbContext();
            db.Eleves.Add(new Eleve { Matricule = "AUTO", Nom = "Nouveau", Prenom = "Test", Sexe = 'M' });
            db.SaveChanges();
            ChargerEleves();
        }
    }
}
