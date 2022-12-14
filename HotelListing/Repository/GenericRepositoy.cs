using HotelListing.Data;
using HotelListing.DTOS;
using HotelListing.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using X.PagedList;

namespace HotelListing.Repository
{
    public class GenericRepositoy<T> : IGenericRepositoy<T> where T : class
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<T> _db;

        public GenericRepositoy( DatabaseContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }

        public async Task Delete(int id)
        {
            var entity = await _db.FindAsync(id);
            _db.Remove(entity);

        }

        public  void DeleteRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null)
        {
            IQueryable<T> query = _db;

            if (includes !=null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<IList<T>> GetAll(
                        Expression<Func<T, bool>> expression = null
                         ,Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null
                         , List<string> includes = null)
        {
            IQueryable<T> query = _db;
            //filtering data before includes or ordering
            if (expression !=null)
            {
                query = query.Where(expression);
            }

            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<T>> GetPagedList(RequestParams requestParams , List<string> includes = null)
        {
            IQueryable<T> query = _db;
            

            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
           

            return await query.AsNoTracking().ToPagedListAsync(
                requestParams.PageNumber,requestParams.PageSize);
        }

        public async Task Insert(T entity)
        {
           await _db.AddAsync(entity);    
        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
