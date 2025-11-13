using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taratra.Models;

namespace Taratra.Models
{
    public class SystemeEvaluation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Classe))]
        public int ClasseId { get; set; }
        public Classe Classe { get; set; }

        [ForeignKey(nameof(Matiere))]
        public int MatiereId { get; set; }
        public Matiere Matiere { get; set; }

        [ForeignKey(nameof(TypeEvaluation))]
        public int TypeEvaluationId { get; set; }
        public TypeEvaluation TypeEvaluation { get; set; }

        public double Coefficient { get; set; } = 1;

        public ICollection<Note>? Notes { get; set; }
    }
}
