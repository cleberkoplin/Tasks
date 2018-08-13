using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using Tasks.Data.Base;
using Tasks.Data.Repositories.Interfaces;

namespace Tasks.Data.Repositories
{
    public class QueryRepository<T> : IQueryRepository<T> where T: EntityBase
    {
        protected DbContext Context { get; set; }
        protected DbSet<T> Entities { get; set; }

        public QueryRepository(DbContext context)
        {
            Context = context;
            Entities = Context.Set<T>();
        }

        public T Get(long id)
        {
            var result = Entities.Where(x => x.Id == id).AsQueryable();
            return result.FirstOrDefault();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            var result = Entities.Where(predicate).AsQueryable();
            return result;
        }

    }
}
