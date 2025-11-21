using WebApp.Models;

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
    private static List<OperationalTask> _tasks = new()
    {
        new OperationalTask
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
        new OperationalTask
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
        new OperationalTask
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
        new OperationalTask
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
        new OperationalTask
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
    };

    private static int _nextId = 6;

    public List<OperationalTask> GetAllTasks()
    {
        return _tasks.OrderByDescending(t => t.CreatedDate).ToList();
    }

    public OperationalTask? GetTaskById(int id)
    {
        return _tasks.FirstOrDefault(t => t.Id == id);
    }

    public void AddTask(OperationalTask task)
    {
        task.Id = _nextId++;
        task.CreatedDate = DateTime.Now;
        _tasks.Add(task);
    }

    public void UpdateTask(OperationalTask task)
    {
        var existingTask = _tasks.FirstOrDefault(t => t.Id == task.Id);
        if (existingTask != null)
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
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task != null)
        {
            _tasks.Remove(task);
        }
    }

    public List<OperationalTask> GetTasksByStatus(OperationalTaskStatus status)
    {
        return _tasks.Where(t => t.Status == status).OrderByDescending(t => t.CreatedDate).ToList();
    }

    public Dictionary<OperationalTaskStatus, int> GetTaskStatistics()
    {
        return _tasks.GroupBy(t => t.Status)
                     .ToDictionary(g => g.Key, g => g.Count());
    }
}
