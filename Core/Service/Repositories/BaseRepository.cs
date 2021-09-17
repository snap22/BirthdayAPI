using BirthdayAPI.Infrastructure.Persistence.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System;
using BirthdayAPI.Core.Service.Query.Sorting;
using BirthdayAPI.Core.Service.Query.Parameters;

namespace BirthdayAPI.Core.Service.Repositories
{
    public abstract class BaseRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly ISortHelper<T> _sortHelper;

        public BaseRepository(ApplicationDbContext context, ISortHelper<T> sortHelper)
        {
            this._context = context;
            this._sortHelper = sortHelper;
        }

        public virtual async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Edit(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        
        public  void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        protected async Task<IEnumerable<T>> GetPagedResult(IQueryable<T> source, QueryStringParameters parameters)
        {
            return await source
                .Skip((parameters.Page - 1) * (parameters.PageSize))
                .Take(parameters.PageSize)
                .ToListAsync();
        }

        protected IQueryable<T> FilterByCondition(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>()
                .Where(expression)
                .AsNoTracking();    // Read Only

        }
    }
}
