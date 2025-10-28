using Core.Application.Paginations.Extensions;
using Core.Application.Paginations.Models;
using Core.Application.Ports.Repositories;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.Persistence.Repositories
{
    public class BaseRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : BaseEntity where TContext : DbContext
    {
        private readonly TContext _context;

        public BaseRepository(TContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null,
            bool tracking = true,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> include = null,
            Expression<Func<TEntity, object>> orderBy = null,
            Expression<Func<TEntity, object>> orderByDesc = null,
            Expression<Func<TEntity, bool>> expression = null)
        {
            IQueryable<TEntity> queryable = _context.Set<TEntity>().AsQueryable();
            queryable = queryable.Where(q => !q.Deleted);

            if (!tracking)
                queryable = queryable.AsNoTracking();

            if (include is not null)
                queryable = include(queryable);

            if (predicate is not null)
                queryable = queryable.Where(predicate).AsQueryable();

            if (orderBy is not null)
                queryable = queryable.OrderBy(orderBy);

            if (orderByDesc is not null)
                queryable = queryable.OrderByDescending(orderByDesc);

            if (expression is not null)
                queryable = queryable.Where(expression).AsQueryable();

            return queryable;
        }

        public async Task<List<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            bool tracking = true,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> include = null,
            Expression<Func<TEntity, object>> orderBy = null,
            Expression<Func<TEntity, object>> orderByDesc = null,
            Expression<Func<TEntity, bool>> expression = null)
        {
            IQueryable<TEntity> queryable = _context.Set<TEntity>().AsQueryable();
            queryable = queryable.Where(q => !q.Deleted);

            if (!tracking)
                queryable = queryable.AsNoTracking();

            if (include is not null)
                queryable = include(queryable);

            if (predicate is not null)
                queryable = queryable.Where(predicate).AsQueryable();

            if (orderBy is not null)
                queryable = queryable.OrderBy(orderBy);

            if (orderByDesc is not null)
                queryable = queryable.OrderByDescending(orderByDesc);

            if (expression is not null)
                queryable = queryable.Where(expression).AsQueryable();

            return await queryable.ToListAsync();
        }

        public PageResponse<TEntity> GetAllWithPagination(int size = 8,
            int index = 1,
            Expression<Func<TEntity, bool>> predicate = null,
            bool tracking = true,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> include = null,
            Expression<Func<TEntity, object>> orderBy = null,
            Expression<Func<TEntity, object>> orderByDesc = null)
        {
            IQueryable<TEntity> queryable =
                GetAll(predicate, tracking, include, orderBy: orderBy, orderByDesc: orderByDesc);

            return queryable.ToPageable<TEntity>(index, size);
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Where(e => !e.Deleted).FirstOrDefault(e => e.Id == id);
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            return _context.Set<TEntity>().Where(e => !e.Deleted).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<TEntity> GetFirst(Expression<Func<TEntity, bool>> predicate = null, bool tracking = true)
        {
            IQueryable<TEntity> queryable = _context.Set<TEntity>();
            queryable = queryable.Where(q => !q.Deleted);

            if (!tracking)
                queryable = queryable.AsNoTracking();

            if (predicate is not null)
                queryable = queryable.Where(predicate).AsQueryable();

            return await queryable.FirstOrDefaultAsync();
        }

        public void HardDeleteById(int id)
        {
            TEntity entityToDelete = _context.Set<TEntity>().FirstOrDefault(e => e.Id == id);
            _context.Set<TEntity>().Remove(entityToDelete);
        }

        public async Task HardDeleteByIdAsync(int id)
        {
            TEntity entityToDelete = await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
            _context.Set<TEntity>().Remove(entityToDelete);
        }

        public void SoftDeleteById(int id)
        {
            TEntity entity = _context.Set<TEntity>().FirstOrDefault(e => e.Id == id);
            entity.Deleted = true;
            _context.Update(entity);
        }

        public async Task SoftDeleteByIdAsync(int id)
        {
            TEntity entity = await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
            entity.Deleted = true;
            _context.Update(entity);
        }

        public TEntity Update(TEntity entity)
        {
            TEntity updatedEntity = _context.Set<TEntity>().Update(entity).Entity;

            return updatedEntity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            TEntity updatedEntity = _context.Set<TEntity>().Update(entity).Entity;

            return updatedEntity;
        }

        public IQueryable<TEntity> Query()
        {
            return _context.Set<TEntity>();
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public PageResponse<TEntity> GetQueryableAsPageResponse(IQueryable<TEntity> queryable, int index, int size)
        {
            return queryable.ToPageable<TEntity>(index, size);
        }
    }
}