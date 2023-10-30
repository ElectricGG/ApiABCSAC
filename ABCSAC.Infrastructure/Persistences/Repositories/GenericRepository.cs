using ABCSAC.Infrastructure.Persistences.Context;
using ABCSAC.Infrastructure.Persistences.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using ABCSAC.Domain.Entities;

namespace ABCSAC.Infrastructure.Persistences.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DBContext _context;
        private readonly DbSet<T> _entity;
        public GenericRepository(DBContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var getAll = await _entity.AsNoTracking().ToListAsync();
            return getAll;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            var getById = await _entity!.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
            return getById!;
        }
        public async Task<bool> RegisterAsync(T entity)
        {
            await _context.AddAsync(entity);

            var recordAffected = await _context.SaveChangesAsync();

            return recordAffected > 0;
        }
        public async Task<bool> EditAsync(T entity)
        {
            _context.Update(entity);
            var recordAffected = await _context.SaveChangesAsync();
            return recordAffected > 0;
        }
        public async Task<bool> RemoveAsync(int id)
        {
            var _ent = GetByIdAsync(id).Result;
            _context.Remove(_ent);
            var recordAffected = await _context.SaveChangesAsync();
            return recordAffected > 0;
        }
        public IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _entity;
            if (filter != null) query = query.Where(filter);

            return query;
        }

        public IQueryable<T> GetAllQueryable()
        {
            var getAllQuery = GetEntityQuery();
            return getAllQuery;
        }
        
        public async Task<IEnumerable<T>> GetSelectAsync()
        {
            var getAll = await _entity
                .AsNoTracking()
                .ToListAsync();
            return getAll;
        }
        
        
       
    }
}
