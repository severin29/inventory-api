using Inventory.Api.Models;

namespace Inventory.Api.Repositories;

public interface IInventoryRepository
{
    IEnumerable<InventoryItem> GetAll();
    InventoryItem? GetById(Guid id);
    void Add(InventoryItem item);
    void Update(InventoryItem item);
    void Delete(Guid id);
}