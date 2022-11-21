using Microsoft.EntityFrameworkCore.Query;
using Processos.Dominio.Core;
using System.Linq.Expressions;

namespace Processos.Dominio.Interfaces.Comum
{
    public interface IBaseRepository<T> where T : Registro
    {
        Task<T> Add(T model);
        Task<T> Update(T model);
        Task<T> Delete(int id);
        Task<T> GetById(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
        Task<IEnumerable<T>> GetAll(
          Expression<Func<T, bool>>? predicate = null,
          Func<IQueryable<T>,
          IIncludableQueryable<T, object>>? include = null,
          int? skip = null,
          int? take = null);
        Task<int> CountAll(Expression<Func<T, bool>>? predicate = null);
        IQueryable<T> FirstQuery();
    }
}
