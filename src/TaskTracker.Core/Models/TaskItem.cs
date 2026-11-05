namespace TaskTracker.Core.Models;

/// <summary>
/// Represents a task item.
/// </summary>
public class TaskItem
{
    /// <summary>
    /// Gets the ID of the task item.
    /// </summary>
    public int Id { get; }
    /// <summary>
    /// Gets the title of the task item.
    /// </summary>
    public string Title { get; private set; }
    /// <summary>
    /// Gets the priority of the task item.
    /// </summary>
    public Priority Priority { get; private set; }
    /// <summary>
    /// Gets the due date of the task item.
    /// </summary>
    public DateOnly? DueDate { get; private set; }
    /// <summary>
    /// Gets the status of the task item.
    /// </summary>
    public bool IsCompleted { get; private set; }
    /// <summary>
    /// Initializes a new instance of the <see cref="TaskItem"/> class.
    /// </summary>
    /// <param name="id">ID of the task item.</param>
    /// <param name="title">Title of the task item.</param>
    /// <param name="priority">Priority of the task item.</param>
    /// <param name="dueDate">Due date of the task item. Can be null.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="id"/> is negative or zero.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="title"/> null, empty, or contains white spaces.</exception>
    public TaskItem(int id, string title, Priority priority, DateOnly? dueDate = null)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);
        ArgumentException.ThrowIfNullOrWhiteSpace(title);

        Id = id;
        Title = title;
        Priority = priority;
        DueDate = dueDate;
        IsCompleted = false;
    }
    /// <summary>
    /// Sets task item as completed.
    /// </summary>
    public void Complete()
    {
        IsCompleted = true;
    }
}
