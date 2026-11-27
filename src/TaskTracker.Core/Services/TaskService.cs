using TaskTracker.Core.Models;
using TaskTracker.Core.Repositories;

namespace TaskTracker.Core.Services;

/// <summary>
/// Represents services for task repository.
/// </summary>
public class TaskService
{
    /// <summary>
    /// The repository of a task items.
    /// </summary>
    private readonly ITaskRepository _repository;

    /// <summary>
    /// Initializes a new instance of <see cref="TaskService"/> class.
    /// </summary>
    /// <param name="repository">The repository of task items.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="repository"/> is null.</exception>
    public TaskService(ITaskRepository repository)
    {
        ArgumentNullException.ThrowIfNull(repository);
        _repository = repository;
    }

    /// <summary>
    /// Gets the list of pending task items.
    /// </summary>
    /// <returns>Read only list of pending task items.</returns>
    public IReadOnlyList<TaskItem> GetPending()
    {
        return [.. _repository
        .GetAll()
        .Where(task => !task.IsCompleted)];
    }

    /// <summary>
    /// Gets the list of pending task items with a due date before today’s date.
    /// </summary>
    /// <param name="today">Today's date.</param>
    /// <returns>Read only list with pending task items with a due date before today’s date.</returns>
    public IReadOnlyList<TaskItem> GetOverdue(DateOnly today)
    {
        return [.. GetPending()
        .Where(task => task.DueDate is not null && task.DueDate < today)
        .OrderBy(task => task.DueDate)
        .ThenByDescending(task => task.Priority)];
    }
}
