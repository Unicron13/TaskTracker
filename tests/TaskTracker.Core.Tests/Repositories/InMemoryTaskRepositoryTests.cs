using TaskTracker.Core.Models;
using TaskTracker.Core.Repositories;

namespace TaskTracker.Core.Tests.Repositories;

public class InMemoryTaskRepositoryTests
{
    private readonly InMemoryTaskRepository _repository = new();

    [Fact]
    public void Add_NewTasks_AssignCorrectId()
    {
        // Given
        var firstTask = _repository.Add("task1", Priority.Medium);
        var secondTask = _repository.Add("task2", Priority.Medium);

        // When + Then
        Assert.Equal(1, firstTask.Id);
        Assert.Equal(2, secondTask.Id);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void Add_InvalidTitle_ThrowsArgumentException(string title)
    {
        // Given + When + Then
        var ex = Assert.Throws<ArgumentException>(() => _repository.Add(title, Priority.Medium));
        Assert.Equal("title", ex.ParamName);
    }

    [Fact]
    public void Add_AfterFailedAdd_AssignsUnusedIdForNextTask()
    {
        // Given
        Assert.Throws<ArgumentException>(() => _repository.Add(" ", Priority.Medium));

        // When
        var secondTask = _repository.Add("title", Priority.Low);

        // Then
        Assert.Equal(1, secondTask.Id);
    }

    [Fact]
    public void GetById_ExistingTaskItem_ReturnsSameTaskItem()
    {
        // Given
        _repository.Add("Task Item", Priority.Medium);
        var taskItem2 = _repository.Add("Task item 2", Priority.Medium);

        // When + Then
        Assert.Same(taskItem2, _repository.GetById(2));
    }

    [Fact]
    public void GetById_NonexistingTaskItem_ReturnsNull()
    {
        // Given
        _repository.Add("Task Item", Priority.Medium);

        // When + Then
        Assert.Null(_repository.GetById(2));
    }

    [Fact]
    public void GetAll_EmptyRepository_ReturnsEmptyList()
    {
        // Given + When + Then
        Assert.Empty(_repository.GetAll());
    }

    [Fact]
    public void GetAll_TaskAddedAfterCall_DoesNotChangeReturnedList()
    {
        // Given
        _repository.Add("Task Item 1", Priority.Medium);
        _repository.Add("Task Item 2", Priority.Medium);
        var snapshot = _repository.GetAll();

        // When
        _repository.Add("Task Item 3", Priority.Medium);

        // Then
        Assert.Equal(2, snapshot.Count);
    }

    [Fact]
    public void Remove_ExistingTaskItem_ReturnsTrue()
    {
        // Given
        _repository.Add("Task Item 1", Priority.Medium);
        _repository.Add("Task Item 2", Priority.Medium);

        // When + Then
        Assert.True(_repository.Remove(2));
    }

    [Fact]
    public void GetById_AfterRemovedExistingTaskItem_ReturnsNull()
    {
        // Given
        _repository.Add("Task Item 1", Priority.Medium);
        _repository.Add("Task Item 2", Priority.Medium);

        // When
        _repository.Remove(2);

        // Then
        Assert.Null(_repository.GetById(2));
    }

    [Fact]
    public void Remove_NonexistingTaskItem_ReturnsFalse()
    {
        // Given
        _repository.Add("Task Item 1", Priority.Medium);

        // When + Then
        Assert.False(_repository.Remove(2));
    }
}
