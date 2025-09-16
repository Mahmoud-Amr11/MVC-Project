using System.Linq.Expressions;

namespace Demo.DataAccess.Repository
{
    public interface IRepository<T> where T : class
    {

        public  Task<T?> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes);
       IQueryable<T> Get(Expression<Func<T,bool>> filter=null! ,params Expression<Func<T, object>>[] includes );

        public  IQueryable<T> Find(Expression<Func<T, bool>> filter);

        Task Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
