using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Taratra.Models;
using Taratra.Services.Interfaces;

namespace Taratra.Services
{
    public class EcoleService : IEcoleService
    {
        private readonly TaratraDbContext _dbContext;

        public EcoleService(TaratraDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddEcole(string ecoleName, string adresse, string proviseurName)
        {
            Ecole ecole = new Ecole();
            ecole.Nom = ecoleName;
            ecole.Adresse= adresse;
            ecole.ProviseurName = proviseurName;
            try
            {
                await _dbContext.Ecoles.AddAsync(ecole);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
            }

        }
    }
}
