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
    public class ClasseService : IClasseService
    {
        private readonly TaratraDbContext _context;

        public ClasseService(TaratraDbContext context)
        {
            _context = context;
        }

        public async Task<List<Classe>> GetAll()
        {
            return await _context.Classes.ToListAsync();
        }

        public async Task<Classe> GetById(int id)
        {
            return await _context.Classes.FindAsync(id);
        }

    
        public async Task Add(Classe entity)
        {
            var exist =await  _context.Classes
                                          .Where(c=>c.Nom.Trim() == entity.Nom.Trim())
                                          .Select(c=>c).ToListAsync();
            if (exist.Any())
                throw new Exception("Cette classe existe déjà.");
            await _context.Classes.AddAsync(entity);
           
        }

        public async Task Update(int id, Classe entity)
        {
            var existing = await _context.Classes.FindAsync(id);
            if (existing == null) return;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var classe = await _context.Classes.FindAsync(id);
            if (classe == null) return;

            _context.Classes.Remove(classe);
            await _context.SaveChangesAsync();
        }

        public async Task<int> Count()
        {
            return await _context.Classes.CountAsync();  
        }

        public async Task<PaginatedResult<Classe>> GetPaginatedAsync(int page, int pageSize)
        {

            var result = new PaginatedResult<Classe>();
            result.Page = page;
            result.PageSize = pageSize;

            result.TotalCount = await _context.Classes.CountAsync();
            result.Items = await _context.Classes
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return result;
        }
    }

}
