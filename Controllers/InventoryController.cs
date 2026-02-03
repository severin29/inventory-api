using Inventory.Api.DTOs;
using Inventory.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Controllers;

[ApiController]
[Route("api/inventory")]
public class InventoryController : ControllerBase
{
    private readonly IInventoryService _service;

    public InventoryController(IInventoryService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Create(CreateInventoryItemDto dto)
    {
        var item = _service.Create(dto);
        return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
    }

    [HttpGet]
    public IActionResult GetAll(
        [FromQuery] string? name,
        [FromQuery] int? minQuantity)
        => Ok(_service.GetAll(name, minQuantity));

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
        => Ok(_service.GetById(id));

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, UpdateInventoryItemDto dto)
        => Ok(_service.Update(id, dto));

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        _service.Delete(id);
        return NoContent();
    }

    [HttpGet("report")]
    public IActionResult GetReport()
        => Ok(_service.GetReport());
}