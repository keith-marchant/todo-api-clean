using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TodoApp.Application.Entities;

namespace TodoApp.Infrastructure.Persistence.Configuration
{
    public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.HasKey(p => p.ItemId);

            builder.Property(t => t.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.Description)
                .IsUnicode(true);

            builder.Property(p => p.Status)
                .HasConversion<int>();
        }
    }
}
