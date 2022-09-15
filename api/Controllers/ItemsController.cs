using api.Db;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemsController : ControllerBase
{
    private readonly ItemContext _context;

    public ItemsController(ItemContext context)
    {
        _context = context;
    }
    
    [HttpPatch("{id}")]
    public IActionResult Update([FromBody] JsonPatchDocument<Item> request, Guid id)
    {
        var itemToPatch = _context.Items.FirstOrDefault(i => i.Id == id);
        request.ApplyTo(itemToPatch!);
        
        var updatedItem = _context.Items.FirstOrDefault(i => i.Id == id);

        return Ok(updatedItem);
    }

    [HttpGet]
    public IActionResult Get()
    {
        var items = _context.Items.ToList();
        return Ok(items);
    }
}