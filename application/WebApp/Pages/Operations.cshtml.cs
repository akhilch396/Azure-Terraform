using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Pages;

public class OperationsModel : PageModel
{
    private readonly IOperationalTaskService _taskService;

    public OperationsModel(IOperationalTaskService taskService)
    {
        _taskService = taskService;
    }

    public List<OperationalTask> Tasks { get; set; } = new();
    public Dictionary<OperationalTaskStatus, int> Statistics { get; set; } = new();
    public int TotalTasks { get; set; }
    public int CompletedTasks { get; set; }
    public int PendingTasks { get; set; }
    public int InProgressTasks { get; set; }

    public void OnGet()
    {
        Tasks = _taskService.GetAllTasks();
        Statistics = _taskService.GetTaskStatistics();
        
        TotalTasks = Tasks.Count;
        CompletedTasks = Statistics.GetValueOrDefault(OperationalTaskStatus.Completed, 0);
        PendingTasks = Statistics.GetValueOrDefault(OperationalTaskStatus.Pending, 0);
        InProgressTasks = Statistics.GetValueOrDefault(OperationalTaskStatus.InProgress, 0);
    }
}
