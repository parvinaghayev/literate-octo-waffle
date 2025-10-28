using System.Linq.Expressions;
using Core.Application.Paginations.Models;
using Core.Domain.Entities;

namespace Core.Application.Ports.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        void Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void HardDeleteById(int id);
        Task HardDeleteByIdAsync(int id);
        void SoftDeleteById(int id);
        Task SoftDeleteByIdAsync(int id);
        TEntity Update(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        TEntity GetById(int id);
        Task<TEntity> GetByIdAsync(int id);

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null,
            bool tracking = true,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> include = null,
            Expression<Func<TEntity, object>> orderBy = null,
            Expression<Func<TEntity, object>> orderByDesc = null,
            Expression<Func<TEntity, bool>> expression = null);

        Task<List<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            bool tracking = true,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> include = null,
            Expression<Func<TEntity, object>> orderBy = null,
            Expression<Func<TEntity, object>> orderByDesc = null,
            Expression<Func<TEntity, bool>> expression = null);

        PageResponse<TEntity> GetAllWithPagination(int size = 8,
            int index = 1,
            Expression<Func<TEntity, bool>> predicate = null,
            bool tracking = true,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> include = null,
            Expression<Func<TEntity, object>> orderBy = null,
            Expression<Func<TEntity, object>> orderByDesc = null);

        Task<TEntity> GetFirst(Expression<Func<TEntity, bool>> predicate = null, bool tracking = true);
        IQueryable<TEntity> Query();

        Task SaveChangesAsync();
        PageResponse<TEntity> GetQueryableAsPageResponse(IQueryable<TEntity> queryable, int index, int size);
    }
}