using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taratra.Models;
using Taratra.Services.Interfaces;

namespace Taratra.Services
{
    /// <summary>
    /// Service qui gere la logique metier du systeme d evaluation où on configure 
    ///   la coefficient d'une matiere par rapport au classe et au type d evaluation
    /// </summary>
    public class SystemeEvaluationService : ISystemeEvaluationService
    {
        private TaratraDbContext _taratraDbContext;
        public SystemeEvaluationService(TaratraDbContext taratraDbContext)
        {
            _taratraDbContext = taratraDbContext;
        }

        public async Task Add(SystemeEvaluation entity)
        {
            await _taratraDbContext.SystemeEvaluations.AddAsync(entity);
           await _taratraDbContext.SaveChangesAsync();
        }

        public Task<int> Count()
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SystemeEvaluation>> GetAll()
        {
            return await _taratraDbContext.SystemeEvaluations.ToListAsync();
        }

        public async Task<SystemeEvaluation> GetById(int id)
        {
            return await _taratraDbContext.SystemeEvaluations.FindAsync(id);
        }

        public Task<PaginatedResult<SystemeEvaluation>> GetPaginatedAsync(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, SystemeEvaluation entity)
        {
            throw new NotImplementedException();
        }
    }
}
