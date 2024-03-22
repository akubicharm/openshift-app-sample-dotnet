using BlazorTodo.Models;

namespace BlazorTodo.Services;

public interface ITodoService
{
    public Task<TodoItem[]> GetTodosAsync();

    public Task PostTodoAsync(TodoItem todo);

    public Task PutTodoAsync(long id, TodoItem todo);

    public Task DeleteTodoAsync(long id);
}
