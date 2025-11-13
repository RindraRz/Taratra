using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Taratra.Models
{
    public class Classe
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }

        public ICollection<Inscription>? Inscriptions { get; set; }
        public ICollection<SystemeEvaluation>? SystemesEvaluations { get; set; }
    }
}

