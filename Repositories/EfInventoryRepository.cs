using Inventory.Api.Data;
using Inventory.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Api.Repositories;

public class EfInventoryRepository : IInventoryRepository
{
    private readonly AppDbContext _db;

    public EfInventoryRepository(AppDbContext db)
    {
        _db = db;
    }

    public IEnumerable<InventoryItem> GetAll()
        => _db.InventoryItems.AsNoTracking().ToList();

    public InventoryItem? GetById(Guid id)
        => _db.InventoryItems.Find(id);

    public void Add(InventoryItem item)
    {
        _db.InventoryItems.Add(item);
        _db.SaveChanges();
    }

    public void Update(InventoryItem item)
    {
        _db.InventoryItems.Update(item);
        _db.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var item = GetById(id);
        if (item == null) return;
        _db.InventoryItems.Remove(item);
        _db.SaveChanges();
    }
}