using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taratra.Models
{
    public class SystemeConfig
    {
        public required List<TypeEvaluation> Evaluations { get; set; }
        public int PeriodNumber { get; set; } = 3;
        public string PeriodLibelle { get; set; } = "Trimestre";

        public required string ProviseurName { get; set; }

        public required string EcoleName {  get; set; }

        public required string EcoleAdresse { get; set; }







    }
}
