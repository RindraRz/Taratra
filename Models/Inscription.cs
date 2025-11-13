using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taratra.Models;

namespace Taratra.Models
{
    public class Inscription
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Eleve))]
        public int EleveId { get; set; }
        public Eleve Eleve { get; set; }

        [ForeignKey(nameof(Classe))]
        public int ClasseId { get; set; }
        public Classe Classe { get; set; }

        [ForeignKey(nameof(AnneeScolaire))]
        public int AnneeScolaireId { get; set; }
        public AnneeScolaire AnneeScolaire { get; set; }

        public string? Situation { get; set; } // Passant, Redoublant, etc.
        public string? Option { get; set; }
    }
}
