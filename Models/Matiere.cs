using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Taratra.Models;

namespace Taratra.Models
{
    public class Matiere
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }

        public string? CodeMatiere { get; set; }

        public ICollection<SystemeEvaluation>? SystemesEvaluations { get; set; }
    }
}
