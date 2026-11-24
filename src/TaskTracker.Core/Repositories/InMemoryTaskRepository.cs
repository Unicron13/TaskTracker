using TaskTracker.Core.Models;

namespace TaskTracker.Core.Repositories;

/// <summary>
/// Represents an in-memory repository of task items.
/// </summary>
public class InMemoryTaskRepository : ITaskRepository
{
    /// <summary>
    /// List of task items.
    /// </summary>
    private readonly OrderedDictionary<int, TaskItem> _tasksById = [];

    /// <summary>
    /// The ID that will be assigned to the next added task item.
    /// </summary>
    private int _nextId = 1;

    /// <inheritdoc/>
    public TaskItem Add(string title, Priority priority, DateOnly? dueDate = null)
    {
        var task = new TaskItem(_nextId, title, priority, dueDate);

        _tasksById.Add(task.Id, task);
        _nextId++;

        return task;
    }

    /// <inheritdoc/>
    public IReadOnlyList<TaskItem> GetAll()
    {
        return [.. _tasksById.Values];
    }

    /// <inheritdoc/>
    public TaskItem? GetById(int id)
    {
        return _tasksById.GetValueOrDefault(id);
    }

    /// <inheritdoc/>
    public bool Remove(int id)
    {
        return _tasksById.Remove(id);
    }
}
