using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Taratra.Models;

namespace Taratra.Models
{
    public class TypeEvaluation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; } // DS, Examen...

        public int? Ordre { get; set; }

        public bool Actif { get; set; } = true;

        public ICollection<SystemeEvaluation>? SystemesEvaluations { get; set; }
    }
}
