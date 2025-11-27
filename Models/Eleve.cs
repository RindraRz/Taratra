using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Taratra.Models;

namespace Taratra.Models
{
    public class Eleve
    {
        [Key]
        public int Id { get; set; }

        public string? Matricule { get; set; }

        [Required]
        public string? Nom { get; set; }

        public string? Prenom { get; set; }

        public DateTime? DateNaissance { get; set; }

        public char Sexe { get; set; }

        public ICollection<Inscription>? Inscriptions { get; set; }
        public ICollection<Note>? Notes { get; set; }

        public string NomComplet => $"{Prenom} {Nom}";
    }
}
