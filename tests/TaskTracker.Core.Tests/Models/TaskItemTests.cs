using TaskTracker.Core.Models;

namespace TaskTracker.Core.Tests.Models;

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

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_InvalidTitle_ThrowsArgumentException(string title)
    {
        // Given + When + Then
        var ex = Assert.Throws<ArgumentException>(() => new TaskItem(1, title, Priority.Medium));
        Assert.Equal("title", ex.ParamName);
    }

    [Fact]
    public void Constructor_NullTitle_ThrowsArgumentNullException()
    {
        // Given + When + Then
        var ex = Assert.Throws<ArgumentNullException>(() => new TaskItem(1, null!, Priority.Medium));
        Assert.Equal("title", ex.ParamName);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Constructor_InvalidId_ThrowsArgumentOutOfRangeException(int id)
    {
        // Given + When + Then
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new TaskItem(id, "task", Priority.Medium));
        Assert.Equal("id", ex.ParamName);
    }
}
