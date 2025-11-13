using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Taratra.Models
{
    public class Periode
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Libelle { get; set; } // Trimestre 1, etc.

        public int? Ordre { get; set; }

        public bool Actif { get; set; } = true;

        public ICollection<Note>? Notes { get; set; }
    }
}
