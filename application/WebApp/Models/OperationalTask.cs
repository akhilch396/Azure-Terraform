namespace WebApp.Models;

public class OperationalTask
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public OperationalTaskStatus Status { get; set; }
    public TaskPriority Priority { get; set; }
    public string AssignedTo { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime? CompletedDate { get; set; }
    public string Category { get; set; } = string.Empty;
}

public enum OperationalTaskStatus
{
    Pending,
    InProgress,
    Completed,
    Blocked,
    Cancelled
}

public enum TaskPriority
{
    Low,
    Medium,
    High,
    Critical
}
