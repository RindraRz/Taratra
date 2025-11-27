using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taratra.Models;

namespace Taratra.Services.Interfaces
{
    public interface ICrud<T>
    {
        Task<List<T>> GetAll();

        
        Task<PaginatedResult<T>> GetPaginatedAsync(int page, int pageSize);

        Task<T> GetById(int id);
        

        Task Add(T entity);
        Task Update(int id,T entity);

        Task Delete(int id);

        Task<int> Count();
    }
}
