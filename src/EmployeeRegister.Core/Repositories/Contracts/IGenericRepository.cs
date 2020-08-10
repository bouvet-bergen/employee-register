using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EmployeeRegister.Core.Repositories.Contracts
{
    public interface IGenericRepository<TContext, TEntity> where TContext : DbContext where TEntity : class 
    {
        TContext Context { get; set; }
        DbSet<TEntity> DbSet { get; set; }
        IQueryable<TEntity> GetAll(bool asNoTracking = false);
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = false);
        Task<TEntity> GetAsync(int id);
        Task<EntityEntry<TEntity>> CreateAsync(TEntity entity);
        void Update(TEntity entity);
        Task Delete(int id);
        void Detach(TEntity entity);
        Task SaveAsync();
    }
}
