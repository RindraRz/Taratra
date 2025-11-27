using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taratra.Models;

namespace Taratra.Services.Interfaces
{
    public interface IEcoleService
    {
        Task AddEcole(string ecoleName, string adresse, string proviseurName);
    }
}
