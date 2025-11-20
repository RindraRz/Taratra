using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Taratra.Models;
namespace Taratra.Services
{
    public class SystemeConfigService
    {
        private readonly TaratraDbContext _dbContext;
        public SystemeConfigService(TaratraDbContext taratraDbContext)
        {
           _dbContext = taratraDbContext;
        }

        public void SaveSystemeConfig(SystemeConfig sysConfig)
        {
            foreach (var type_evaluation in sysConfig.Evaluations)
            {
                _dbContext.TypeEvaluations.Add(type_evaluation);
            }
            List<Periode> periodes = CreatePeriode(sysConfig.PeriodLibelle, sysConfig.PeriodNumber);
            foreach (var periode in periodes)
            {
                _dbContext.Periodes.Add(periode);
            }
            _dbContext.SaveChanges();
            _dbContext.Dispose();

        }

       

        public List<Periode> CreatePeriode(string libelle,int number)
        {
       
            List<Periode> periodes = new List<Periode>();
            for (int i = 0; i < number; i++) {
                Periode p = new Periode();
                p.Ordre = i + 1;
                p.Libelle = libelle + " "+i+1; 
                periodes.Add(p);
            }
            return periodes;
        }
    }
}
