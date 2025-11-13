using System.ComponentModel.DataAnnotations;

namespace Taratra.Models
{
    public class Eleve
    {
        [Key]
        public int Id { get; set; }
        public string Matricule { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public char Sexe { get; set; }

        public string NomComplet => $"{Prenom} {Nom}";
    }
}
