using Microsoft.EntityFrameworkCore;
using MVC_CodeFirst.Domain;

namespace MVC_CodeFirst.Persistence;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Employee> Employees { get; set; }
}