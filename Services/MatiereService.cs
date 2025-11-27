using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taratra.Models;
using Taratra.Services.Interfaces;

namespace Taratra.Services
{
    public class MatiereService : IMatiereService
    {
        private TaratraDbContext _taratraDbContext;
        public MatiereService(TaratraDbContext taratraDbContext)
        {
            _taratraDbContext = taratraDbContext;
        }
        public async Task Add(Matiere entity)
        {
            var exist = await _taratraDbContext.Matieres
                                         .Where(c => c.Nom.Trim() == entity.Nom.Trim())
                                         .Select(c => c).ToListAsync();
            if (exist.Any())
                throw new Exception("Cette Matière existe déjà.");
            await _taratraDbContext.Matieres.AddAsync(entity);
            await _taratraDbContext.SaveChangesAsync();
        }

        public async Task<int> Count()
        {
            return await _taratraDbContext.Matieres.CountAsync();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Matiere>> GetAll()
        {
           return await _taratraDbContext.Matieres.ToListAsync();
        }

        public async Task<Matiere> GetById(int id)
        {
            return await _taratraDbContext.Matieres.FindAsync(id);
        }

        public Task<PaginatedResult<Matiere>> GetPaginatedAsync(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, Matiere entity)
        {
            throw new NotImplementedException();
        }
    }
}
