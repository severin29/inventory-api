using Inventory.Api.DTOs;
using Inventory.Api.Models;
using Inventory.Api.Repositories;

namespace Inventory.Api.Services;

public class InventoryService : IInventoryService
{
    private readonly IInventoryRepository _repository;

    public InventoryService(IInventoryRepository repository)
    {
        _repository = repository;
    }

    public InventoryItem Create(CreateInventoryItemDto dto)
    {
        if (dto.Quantity < 0)
            throw new ArgumentException("Quantity cannot be negative");

        if (dto.Price < 0)
            throw new ArgumentException("Price cannot be negative");

        var item = new InventoryItem
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Quantity = dto.Quantity,
            Price = dto.Price,
            Supplier = dto.Supplier
        };

        _repository.Add(item);
        return item;
    }

    public IEnumerable<InventoryItem> GetAll(string? name, int? minQuantity)
    {
        var items = _repository.GetAll();

        if (!string.IsNullOrWhiteSpace(name))
            items = items.Where(x =>
                x.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

        if (minQuantity.HasValue)
            items = items.Where(x => x.Quantity >= minQuantity.Value);

        return items;
    }

    public InventoryItem GetById(Guid id)
        => _repository.GetById(id)
           ?? throw new KeyNotFoundException("Item not found");

    public InventoryItem Update(Guid id, UpdateInventoryItemDto dto)
    {
        var item = GetById(id);

        if (dto.Name != null) item.Name = dto.Name;

        if (dto.Quantity.HasValue)
        {
            if (dto.Quantity.Value < 0)
                throw new ArgumentException("Quantity cannot be negative");
            item.Quantity = dto.Quantity.Value;
        }

        if (dto.Price.HasValue)
        {
            if (dto.Price.Value < 0)
                throw new ArgumentException("Price cannot be negative");
            item.Price = dto.Price.Value;
        }

        if (dto.Supplier != null) item.Supplier = dto.Supplier;

        _repository.Update(item);
        return item;
    }

    public void Delete(Guid id)
    {
        GetById(id);
        _repository.Delete(id);
    }

    public InventoryReport GetReport()
    {
        var items = _repository.GetAll();

        return new InventoryReport
        {
            TotalItems = items.Count(),
            TotalQuantity = items.Sum(x => x.Quantity),
            TotalValue = items.Sum(x => x.Quantity * x.Price),
            LowStockItems = items.Where(x => x.Quantity < 5).ToList()
        };
    }
}