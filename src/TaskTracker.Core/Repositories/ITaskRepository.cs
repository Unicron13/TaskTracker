using TaskTracker.Core.Models;

namespace TaskTracker.Core.Repositories;

/// <summary>
/// Defines a contract for the task item repository.
/// </summary>
public interface ITaskRepository
{
    /// <summary>
    /// Creates and saves a task item.
    /// </summary>
    /// <param name="title">Title of the task.</param>
    /// <param name="priority">Priority of the task.</param>
    /// <param name="dueDate">Due date of the task.</param>
    /// <returns>Task item object.</returns>
    TaskItem Add(string title, Priority priority, DateOnly? dueDate = null);

    /// <summary>
    /// Attempts to find a task item.
    /// </summary>
    /// <param name="id">ID of the task item.</param>
    /// <returns>Task item object or null.</returns>
    TaskItem? GetById(int id);

    /// <summary>
    /// Gets the list of all task items.
    /// </summary>
    /// <returns>Read only list of all task items.</returns>
    IReadOnlyList<TaskItem> GetAll();

    /// <summary>
    /// Removes the task item.
    /// </summary>
    /// <param name="id">ID of the task.</param>
    /// <returns>True if the task item is successfully deleted; otherwise, it returns false.</returns>
    bool Remove(int id);
}
