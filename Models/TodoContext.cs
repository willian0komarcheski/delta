using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Models;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    public DbSet<TodoItem> TodoItems { get; set; } = null!;

    public DbSet<TodoApi.Models.TodoLogin> TodoLogin { get; set; } = default!;

    public DbSet<TodoApi.Models.TodoCarrinho> TodoCarrinho { get; set; } = default!;
}