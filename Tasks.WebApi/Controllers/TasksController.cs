using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Tasks.Data.Base;
using Tasks.Data.Entities;
using Tasks.Data.Services.Interfaces;

namespace Tasks.WebApi.Controllers
{

    
    [Produces("application/json")]
    [Route("api")]
    public class TasksController : ControllerBase
    {

        private ITaskService _taskService;
        private TasksContext _context;

        public TasksController(TasksContext context, ITaskService taskService)
        {
            _context = context;
            _taskService = taskService;
        }

        // GET api/values
        [HttpGet("pendent.tasks")]
        public IActionResult GetPendents()
        {
            List<Task> tasks = _taskService.GetAllPendent();
            return Ok(tasks);
        }

        [HttpGet("concluded.tasks")]
        public IActionResult GetConcluded()
        {
            List<Task> tasks = _taskService.GetAllConcluded();
            return Ok(tasks);
        }

        [HttpPost("set.task")]
        public IActionResult Set([FromBody] Task entity)
        {
            if (_taskService.SaveOrUpdate(entity))
            {
                return Ok(entity);
            }
            return Ok(null);
        }

        [HttpPost("update.task")]
        public IActionResult Update([FromBody] Task entity)
        {
            if (_taskService.SaveOrUpdate(entity))
            {
                return Ok(entity);
            }
            return Ok(null);
        }

    }
}
