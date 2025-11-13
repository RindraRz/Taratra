using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Taratra.Models
{
    public class Ecole
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }

        public string? Adresse { get; set; }

        public ICollection<Classe>? Classes { get; set; }
    }


}
