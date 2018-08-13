using System;
using Tasks.Data.Base;
using System.Linq;
using System.Linq.Expressions;

namespace Tasks.Data.Repositories.Interfaces
{
    public interface IQueryRepository<T> where T : IEntity
    {
        T Get(long id);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
    }
}
