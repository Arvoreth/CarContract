using Microsoft.EntityFrameworkCore;
using PracticeExam1.Domain.Models;

namespace PracticeExam1.Infrastructure.MySqlRepositories;

public class MySqlDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Contract> Contracts { get; set; }

    public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options) {}

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        const string connString = "DataSource = localhost; DataBase = CarContract; UserID = root; Password = root";
        // builder.UseMySql(connString, ServerVersion.AutoDetect(connString));
    }
}
