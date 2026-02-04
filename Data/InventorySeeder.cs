using Inventory.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Api.Data;

public class InventorySeeder : IDataSeeder
{
    private readonly AppDbContext _db;

    public InventorySeeder(AppDbContext db)
    {
        _db = db;
    }

    public async Task SeedAsync()
    {
        if (await _db.InventoryItems.AnyAsync())
            return;

        var items = new List<InventoryItem>
        {
            new() { Name = "Laptop Dell XPS", Quantity = 10, Price = 2500, Supplier = "Dell" },
            new() { Name = "iPhone 15", Quantity = 15, Price = 2200, Supplier = "Apple" },
            new() { Name = "Samsung Monitor 27\"", Quantity = 8, Price = 700, Supplier = "Samsung" },
            new() { Name = "Logitech Mouse", Quantity = 50, Price = 45, Supplier = "Logitech" },
            new() { Name = "Mechanical Keyboard", Quantity = 20, Price = 150, Supplier = "Keychron" }
        };

        _db.InventoryItems.AddRange(items);
        await _db.SaveChangesAsync();
    }
}