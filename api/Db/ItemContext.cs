using Microsoft.EntityFrameworkCore;

namespace api.Db;

public class ItemContext : DbContext
{
    public DbSet<Item> Items { get; set; }

    public ItemContext(DbContextOptions<ItemContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().HasData(new List<Item>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Item 1",
                Description = "Pick up groceries"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Item 2",
                Description = "Go to bank"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Item 3",
                Description = "Go to post office"
            }
        });
    }
}
