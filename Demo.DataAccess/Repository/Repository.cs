using Demo.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Demo.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet=_context.Set<T>();
        }



        public async Task Add(T entity)=>await _dbSet.AddAsync(entity);

        public async Task<T?> GetByIdAsync(  int id,  params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }


            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> filter)
        {
            return  _dbSet.Where(filter);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            if (filter != null)
            {
                query= query.Where(filter);

            }
            return query;
        }

       

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);  
        }
    }
}
