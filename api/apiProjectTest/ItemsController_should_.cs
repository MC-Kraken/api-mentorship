using api.Controllers;
using api.Db;
using AutoBogus;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace apiProjectTest;

public class ItemsController_should_
{
    [Fact]
    public void GetAllItems()
    {
        var options = new DbContextOptionsBuilder<ItemContext>().UseInMemoryDatabase(AutoFaker.Generate<string>())
            .Options;
        var context = new ItemContext(options);
        var controller = new ItemsController(context);

        var result = controller.Get();

        // result.Should().Contain(expectedItems);
    }
}