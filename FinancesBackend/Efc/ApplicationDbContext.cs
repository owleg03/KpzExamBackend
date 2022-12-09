using Microsoft.EntityFrameworkCore;

using FinancesBackend.Models;

namespace FinancesBackend.Efc;

public sealed class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Expense> Expenses { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Expense>().HasData(
            new Expense
            {
                Id = 1,
                Name = "Office restock", 
                Value = 245.5, 
                DateTime = DateTime.Now.AddMonths(-3), 
                Category = Category.Office
            },
            new Expense
            {
                Id = 2,
                Name = "Business trip",
                Value = 320.75,
                DateTime = DateTime.Now.AddDays(-12),
                Category = Category.Transportation
            },
            new Expense
            {
                Id = 3,
                Name = "Business dinner",
                Value = 100,
                DateTime = DateTime.Now.AddDays(-1),
                Category = Category.Food
            },
            new Expense
            {
                Id = 4,
                Name = "PC restock",
                Value = 7500.75,
                DateTime = DateTime.Now,
                Category = Category.Tech
            }
        );
    }
}