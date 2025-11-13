using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taratra.Models
{
    class TaratraDbContext: DbContext
    {
        public DbSet<Eleve> Eleves { get; set; }

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
