using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taratra.Models;
using Taratra.Services.Interfaces;

namespace Taratra.Test
{
    public class ClasseServiceMock : IClasseService
    {
        public Task Add(Classe entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Count()
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Classe>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Classe> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Classe>> GetPaginate(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<PaginatedResult<Classe>> GetPaginatedAsync(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, Classe entity)
        {
            throw new NotImplementedException();
        }
    }
}
