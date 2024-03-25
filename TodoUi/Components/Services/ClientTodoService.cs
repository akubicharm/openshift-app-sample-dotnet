using BlazorTodo.Models;
using System.Net.Http.Json;


namespace BlazorTodo.Services;

// BaseAddressはwwwroot/applications.json の値を参照している
public class ClientTodoService(HttpClient http) : ITodoService
{
    public async Task<TodoItem[]> GetTodosAsync()
    {
        return await http.GetFromJsonAsync<TodoItem[]>($"todoitems") ?? [];
    }

    public async Task PostTodoAsync(TodoItem todo)
    {
        await http.PostAsJsonAsync($"todoitems", todo);
        //await http.PostAsJsonAsync($"http://localhost:5196/todoitems", todo);
    }

    public async Task PutTodoAsync(long id, TodoItem todo)
    {
        await http.PutAsJsonAsync($"todos/{id}", todo);
    }

    public async Task DeleteTodoAsync(long id)
    {
        await http.DeleteAsync($"todoitems/{id}");
        //await http.DeleteAsync($"http://localhost:5196/todoitems/{id}");
    }
}
