using System;
using System.Collections.Generic;
using Tasks.Data.Entities;
using Tasks.Data.Repositories.Interfaces;
using Tasks.Data.Services.Interfaces;
using Tasks.Data.ValueObjects;
using System.Linq;

namespace Tasks.Data.Services
{
    public class TaskService : ITaskService
    {
        ITasksRepository<Task> _tasksRepository;

        public TaskService(ITasksRepository<Task> repository)
        {
            _tasksRepository = repository;
        }

        
        public List<Task> GetAllPendent()
        {
            var tasks = _tasksRepository.Get(x => x.Status == TaskStatus.Pendente);
            return tasks != null ? tasks.ToList() : new List<Task>();
        }
        public List<Task> GetAllConcluded()
        {
            return _tasksRepository.Get(x => x.Status == TaskStatus.Concluido).ToList();
        }
        public bool SaveOrUpdate(Task entity)
        {
            try
            {
                if (entity.Id == 0)
                {
                    _tasksRepository.Insert(entity);
                }
                else
                {
                    Task task = _tasksRepository.Get(entity.Id);
                    task.Status = entity.Status;
                    _tasksRepository.Update(task);
                }
                _tasksRepository.Save();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
    }
}
