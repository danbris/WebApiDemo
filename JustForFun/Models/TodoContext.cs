using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace JustForFun.Models
{
    public sealed class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
            if (TodoItems.Any()) return;
            SeedDummyData();
            
        }

        public DbSet<TodoItem> TodoItems { get; set; }


        private void SeedDummyData()
        {
            TodoItems.AddRange(new TodoItem
            {
                IsComplete = false,
                Name = "Todo 1"
            }, new TodoItem
            {
                IsComplete = true,
                Name = "Todo 2"
            });

            SaveChanges();
        }
    }

}
