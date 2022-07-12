using Microsoft.EntityFrameworkCore;
using todoMVC.Models;

namespace todoMVC.Data
{
    public class MVCDBContext : DbContext
    {
        public MVCDBContext(DbContextOptions<MVCDBContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
