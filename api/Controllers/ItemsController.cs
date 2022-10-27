using api.Db;
using api.Requests;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemsController : ControllerBase
{
    private readonly ItemContext _context;
    private readonly IMediator _mediator;

    public ItemsController(ItemContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    [HttpPatch("{id}")]
    public IActionResult Update([FromBody] JsonPatchDocument<Item> request, Guid id)
    {
        var itemToPatch = _context.Items.FirstOrDefault(i => i.Id == id);
        request.ApplyTo(itemToPatch!);
        _context.SaveChanges();

        var updatedItem = _context.Items.FirstOrDefault(i => i.Id == id);

        return Ok(updatedItem);
    }

    [HttpGet]
    public IActionResult Get()
    {
        var items = _mediator.Send(new GetItemsRequest());
        
        return Ok(items);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var item = _context.Items.FirstOrDefault(item => item.Id == id);
        return Ok(item);
    }
}