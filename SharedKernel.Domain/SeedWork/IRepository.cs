using Microsoft.EntityFrameworkCore.Query;
using SharedKernel.Domain.SeedWork;
using System.Linq.Expressions;

namespace SharedKernel.Domain.Seedwork
{
	public interface IRepository<T> where T : BaseEntity
	{
		IUnitOfWork UnitOfWork { get; }
		Task<T> AddAsync(T entity);
        Task<List<T>> GetAllAsync();
		T Update(T entity);
		bool Delete(T entity);
		Task<T> GetWhere(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
    }
}