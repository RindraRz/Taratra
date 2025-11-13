using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taratra.Models;

namespace Taratra.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Eleve))]
        public int EleveId { get; set; }
        public Eleve Eleve { get; set; }

        [ForeignKey(nameof(AnneeScolaire))]
        public int AnneeScolaireId { get; set; }
        public AnneeScolaire AnneeScolaire { get; set; }

        [ForeignKey(nameof(SystemeEvaluation))]
        public int SystemeEvaluationId { get; set; }
        public SystemeEvaluation SystemeEvaluation { get; set; }

        [ForeignKey(nameof(Periode))]
        public int PeriodeId { get; set; }
        public Periode Periode { get; set; }

        public double? NoteObtenue { get; set; }
    }
}
