using WebApp.Models;
using System.Collections.Concurrent;

namespace WebApp.Services;

public interface IOperationalTaskService
{
    List<OperationalTask> GetAllTasks();
    OperationalTask? GetTaskById(int id);
    void AddTask(OperationalTask task);
    void UpdateTask(OperationalTask task);
    void DeleteTask(int id);
    List<OperationalTask> GetTasksByStatus(OperationalTaskStatus status);
    Dictionary<OperationalTaskStatus, int> GetTaskStatistics();
}

public class OperationalTaskService : IOperationalTaskService
{
    private static readonly ConcurrentDictionary<int, OperationalTask> _tasks = new(
        new Dictionary<int, OperationalTask>
        {
            [1] = new OperationalTask
            {
                Id = 1,
                Title = "Database Backup Verification",
                Description = "Verify all database backups completed successfully",
                Status = OperationalTaskStatus.Completed,
                Priority = TaskPriority.High,
                AssignedTo = "Admin Team",
                CreatedDate = DateTime.Now.AddDays(-5),
                DueDate = DateTime.Now.AddDays(-2),
                CompletedDate = DateTime.Now.AddDays(-3),
                Category = "Database Operations"
            },
            [2] = new OperationalTask
            {
                Id = 2,
                Title = "Update Application Configuration",
                Description = "Update configuration settings for production environment",
                Status = OperationalTaskStatus.InProgress,
                Priority = TaskPriority.Medium,
                AssignedTo = "DevOps Team",
                CreatedDate = DateTime.Now.AddDays(-2),
                DueDate = DateTime.Now.AddDays(1),
                Category = "Configuration Management"
            },
            [3] = new OperationalTask
            {
                Id = 3,
                Title = "Security Patch Deployment",
                Description = "Deploy critical security patches to all servers",
                Status = OperationalTaskStatus.Pending,
                Priority = TaskPriority.Critical,
                AssignedTo = "Security Team",
                CreatedDate = DateTime.Now.AddDays(-1),
                DueDate = DateTime.Now.AddDays(2),
                Category = "Security Operations"
            },
            [4] = new OperationalTask
            {
                Id = 4,
                Title = "Performance Monitoring Setup",
                Description = "Configure performance monitoring for new services",
                Status = OperationalTaskStatus.InProgress,
                Priority = TaskPriority.Medium,
                AssignedTo = "Operations Team",
                CreatedDate = DateTime.Now.AddDays(-3),
                DueDate = DateTime.Now.AddDays(3),
                Category = "Monitoring"
            },
            [5] = new OperationalTask
            {
                Id = 5,
                Title = "Log Analysis Review",
                Description = "Review and analyze system logs for anomalies",
                Status = OperationalTaskStatus.Pending,
                Priority = TaskPriority.Low,
                AssignedTo = "Support Team",
                CreatedDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(7),
                Category = "Log Management"
            }
        });

    private static int _nextId = 6;

    public List<OperationalTask> GetAllTasks()
    {
        return _tasks.Values.OrderByDescending(t => t.CreatedDate).ToList();
    }

    public OperationalTask? GetTaskById(int id)
    {
        _tasks.TryGetValue(id, out var task);
        return task;
    }

    public void AddTask(OperationalTask task)
    {
        task.Id = Interlocked.Increment(ref _nextId);
        task.CreatedDate = DateTime.Now;
        _tasks.TryAdd(task.Id, task);
    }

    public void UpdateTask(OperationalTask task)
    {
        if (_tasks.TryGetValue(task.Id, out var existingTask))
        {
            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.Status = task.Status;
            existingTask.Priority = task.Priority;
            existingTask.AssignedTo = task.AssignedTo;
            existingTask.DueDate = task.DueDate;
            existingTask.Category = task.Category;
            
            if (task.Status == OperationalTaskStatus.Completed && existingTask.CompletedDate == null)
            {
                existingTask.CompletedDate = DateTime.Now;
            }
        }
    }

    public void DeleteTask(int id)
    {
        _tasks.TryRemove(id, out _);
    }

    public List<OperationalTask> GetTasksByStatus(OperationalTaskStatus status)
    {
        return _tasks.Values.Where(t => t.Status == status).OrderByDescending(t => t.CreatedDate).ToList();
    }

    public Dictionary<OperationalTaskStatus, int> GetTaskStatistics()
    {
        return _tasks.Values.GroupBy(t => t.Status)
                     .ToDictionary(g => g.Key, g => g.Count());
    }
}
