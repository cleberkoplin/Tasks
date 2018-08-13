using Tasks.Data.Base;

namespace Tasks.Data.Repositories.Interfaces
{
    public interface ITasksRepository<Task> : IQueryRepository<Task> where Task : IEntity
    {
        void Insert(Task entity);
        void Update(Task entity);
        void Delete(Task entity);
        void Save();
    }
}
