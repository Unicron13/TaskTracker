using TaskTracker.Core.Models;

namespace TaskTracker.Core.Tests.Model;

public class TaskItemTests
{
    [Fact]
    public void Constructor_ValidArguments_SetsCorrectProperties()
    {
        // Given
        var taskItem = new TaskItem(1, "Task", Priority.Medium);

        // When + Then
        Assert.Equal(1, taskItem.Id);
        Assert.Equal("Task", taskItem.Title);
        Assert.Equal(Priority.Medium, taskItem.Priority);
        Assert.Null(taskItem.DueDate);
        Assert.False(taskItem.IsCompleted);
    }

    [Fact]
    public void Complete_NewTask_SetsIsCompletedToTrue()
    {
        // Given
        var taskItem = new TaskItem(1, "Task", Priority.Medium);

        // When
        taskItem.Complete();

        // Then
        Assert.True(taskItem.IsCompleted);
    }
}
