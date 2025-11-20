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

    










    }
}
