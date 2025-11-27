using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Taratra.Models
{
    public class AnneeScolaire
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Libelle { get; set; } // ex: "2024-2025"

        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }

        public ICollection<Inscription>? Inscriptions { get; set; }
    }
}
