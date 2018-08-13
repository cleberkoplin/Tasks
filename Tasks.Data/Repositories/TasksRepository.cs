using Microsoft.EntityFrameworkCore;
using Tasks.Data.Base;
using Tasks.Data.Repositories.Interfaces;

namespace Tasks.Data.Repositories
{
    public class TasksRepository<T> : QueryRepository<T>, ITasksRepository<T> where T : EntityBase
    {
        public TasksRepository(DbContext context) : base(context)
        {

        }
        
        public void Insert(T entity)
        {
            Entities.Add(entity);
        }

        public void Update(T entity)
        {
            Context.Entry<T>(entity).State = EntityState.Modified;
        }

        public void Save(T entity)
        {
            if (entity.Id == 0)
            {
                Insert(entity);
            }
            else
            {
                Update(entity);
            }
        }

        public void Delete(T entity)
        {
            Entities.Remove(entity);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

    }
}
