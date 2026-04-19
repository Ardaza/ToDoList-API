using ToDoList.Models;

namespace ToDoList.Repositories
{
    public interface IToDoListRepository
    {
        Task<List<ToDoItem>> GetAllAsync();
        Task<ToDoItem?> GetByIdAsync(int id);
        Task<ToDoItem> CreateAsync(ToDoItem item);
        Task<ToDoItem?> UpdateAsync(int id, ToDoItem item);
        Task<bool> DeleteAsync(int id);
    }
}
