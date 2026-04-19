using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Repositories
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly AppDbContext _context;

        public ToDoListRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ToDoItem>> GetAllAsync()
        {
            return await _context.Todos.ToListAsync();
        }

        public async Task<ToDoItem?> GetByIdAsync(int id)
        {
            return await _context.Todos.FindAsync(id);
        }

        public async Task<ToDoItem> CreateAsync(ToDoItem item)
        {
            _context.Todos.Add(item);

            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<ToDoItem?> UpdateAsync(int id, ToDoItem item)
        {
            var existing = await _context.Todos.FindAsync(id);
            if (existing == null) return null;
        
            existing.Title = item.Title;
            existing.Description = item.Description;
            existing.isCompleted = item.isCompleted;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _context.Todos.FindAsync(id);
            if(item == null) return false;

            _context.Todos.Remove(item);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
