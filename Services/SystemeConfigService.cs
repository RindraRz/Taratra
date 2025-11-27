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
    public interface ISystemeConfigService
    {
        void SaveSystemeConfig(SystemeConfig sysConfig);
        List<Periode> CreatePeriode(string libelle, int number);
        bool IsConfigured();
    }

    public class SystemeConfigService : ISystemeConfigService
    {
        private readonly TaratraDbContext _dbContext;

        public SystemeConfigService(TaratraDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveSystemeConfig(SystemeConfig sysConfig)
        {
           
            if (IsConfigured())
                return;

            _dbContext.TypeEvaluations.AddRange(sysConfig.Evaluations);
            var periodes = CreatePeriode(sysConfig.PeriodLibelle, sysConfig.PeriodNumber);
            _dbContext.Periodes.AddRange(periodes);
            var Ecole = new Ecole
            {
                Nom = sysConfig.EcoleName,
                Adresse = sysConfig.EcoleAdresse,
                ProviseurName = sysConfig.ProviseurName
            };
            _dbContext.Ecoles.Add(Ecole);

            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                // TODO : logger l'erreur
                throw;
            }
        }



        public List<Periode> CreatePeriode(string libelle, int number)
        {
            var periodes = new List<Periode>();

            for (int i = 0; i < number; i++)
            {
                periodes.Add(new Periode
                {
                    Ordre = i + 1,
                    Libelle = $"{libelle} {i + 1}"
                });
            }

            return periodes;
        }
        public bool IsConfigured()
        {
            return _dbContext.TypeEvaluations.Any() || _dbContext.Periodes.Any();
        }

    }

}
