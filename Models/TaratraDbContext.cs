using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taratra.Models
{
    public class TaratraDbContext: DbContext
    {
        public DbSet<Eleve> Eleves { get; set; }
        public DbSet<AnneeScolaire> AnneeScolaires { get; set; }
        public DbSet<Classe> Classes { get; set; }
        public DbSet<Ecole> Ecoles {  get; set; }
        public DbSet<Inscription> Inscriptions { get; set; }
        public DbSet<Matiere> Matieres { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Periode> Periodes { get; set; }
        public DbSet<SystemeEvaluation> SystemeEvaluations { get; set; }
        public DbSet<TypeEvaluation> TypeEvaluations { get; set; }

   




        private string DbPath { get; }

        public TaratraDbContext()
        {
            // Base SQLite stockée localement
            var projectFolder = AppDomain.CurrentDomain.BaseDirectory;
            var folder = Path.GetFullPath(Path.Combine(projectFolder, @"..\..\..\"));
            DbPath = Path.Combine(folder, "database.db");

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }

}
