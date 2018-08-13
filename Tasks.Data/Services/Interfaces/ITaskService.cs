using System.Collections.Generic;
using Tasks.Data.Entities;


namespace Tasks.Data.Services.Interfaces
{
    public interface ITaskService
    {
        List<Task> GetAllPendent();
        List<Task> GetAllConcluded();
        bool SaveOrUpdate(Task entity);
    }
}
