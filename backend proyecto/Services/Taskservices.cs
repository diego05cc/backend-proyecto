﻿
using AWEPP.Repositories;
using backend_proyecto.model;
using System.Threading.Tasks;


namespace AWEPP.Services
{
    public interface TaskServices
    {
        Task<IEnumerable<Task>> GetAllTasksAsync();
        Task<Task> GetTaskByIdAsync(int id);
        Task<Task> CreateTaskAsync(Task task);
        Task<Task> UpdateTaskAsync(Task task);
        backend_proyecto.model.Tasks SoftDeleteTaskAsync(int id);
    }
}