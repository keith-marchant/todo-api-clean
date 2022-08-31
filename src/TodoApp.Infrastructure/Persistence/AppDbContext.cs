using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TodoApp.Application.Entities;

namespace TodoApp.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<TodoItem>? TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            _ = builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
