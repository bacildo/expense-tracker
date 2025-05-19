using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Api.Models;

namespace ExpenseTracker.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts)
            : base(opts) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Exemplo: força nome da tabela
            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Transaction>().ToTable("Transactions");

            // Ex.: relacionamento 1:N
            builder.Entity<Transaction>()
                  .HasOne(t => t.Category)
                  .WithMany(c => c.Transactions)
                  .HasForeignKey(t => t.CategoryId);
        }
    }
}
