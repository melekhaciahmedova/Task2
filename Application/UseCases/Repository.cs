using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using SharedKernel.Domain.Seedwork;
using SharedKernel.Domain.SeedWork;
using System.Linq.Expressions;

namespace Application.UseCases
{
    public abstract class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public abstract DbContext Context { get; protected set; }
        public DbSet<T> Table => Context.Set<T>();
        public IUnitOfWork UnitOfWork => Context as IUnitOfWork;

        public async Task<T> AddAsync(T entity)
        {
            EntityEntry<T> entry = await Table.AddAsync(entity);
            return entry.Entity;
        }

        public T Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public bool Delete(T entity)
        {
            Table.Remove(entity);
            return true;
        }

        public Task<List<T>> GetAllAsync()
        {
            return Table.ToListAsync();
        }

        public async Task<T> GetWhere(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = Table.Where(predicate);

            if (include != null)
            {
                query = include(query);
            }
            return await query.FirstOrDefaultAsync();
        }
    }
}