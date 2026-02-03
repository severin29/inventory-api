using Inventory.Api.DTOs;
using Inventory.Api.Models;

namespace Inventory.Api.Services;

public interface IInventoryService
{
    InventoryItem Create(CreateInventoryItemDto dto);
    IEnumerable<InventoryItem> GetAll(string? name, int? minQuantity);
    InventoryItem GetById(Guid id);
    InventoryItem Update(Guid id, UpdateInventoryItemDto dto);
    void Delete(Guid id);
    InventoryReport GetReport();
}