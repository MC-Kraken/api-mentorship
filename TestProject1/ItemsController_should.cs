using api.Controllers;
using api.Db;
using apiProjectTest.Extensions;
using AutoBogus;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

namespace apiProjectTest;

public class ItemsController_should
{
    [Fact]
    public void GetAllItems()
    {
        // Arrange
        var existingItems = new List<Item>
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
        };
        var options = new DbContextOptionsBuilder<ItemContext>().UseInMemoryDatabase(AutoFaker.Generate<string>())
            .Options;
        var context = new ItemContext(options);
        context.Items.AddRange(existingItems);
        context.SaveChanges();
        var controller = new ItemsController(context);

        // Act
        var result = controller.Get();

        //Assert
        var okObjectResult = result.Should().BeOfTypeAndReturn<OkObjectResult>();
        okObjectResult.Value.Should().BeEquivalentTo(existingItems);
    }
    
    [Fact]

    public void GetById()
    {
        // Arrange
        var existingItems = new List<Item>
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
        };
        var expectedItem = existingItems[0];
        var options = new DbContextOptionsBuilder<ItemContext>().UseInMemoryDatabase(AutoFaker.Generate<string>())
            .Options;
        var context = new ItemContext(options);
        context.Items.AddRange(existingItems);
        context.SaveChanges();
        var controller = new ItemsController(context);

        // Act
        var result = controller.GetById(expectedItem.Id);

        //Assert
        var okObjectResult = result.Should().BeOfTypeAndReturn<OkObjectResult>();
        okObjectResult.Value.Should().Be(expectedItem);
    }

    [Fact]
    public void UpdateAllItems()
    {
        var options = new DbContextOptionsBuilder<ItemContext>().UseInMemoryDatabase(AutoFaker.Generate<string>())
            .Options;
        var context = new ItemContext(options);
        var expectedItem = AutoFaker.Generate<Item>();
        context.Add(expectedItem);
        context.SaveChanges();
        var controller = new ItemsController(context);
        var expectedDescription = "TEST NAME";

        var patchDocument = new JsonPatchDocument<Item>(
            new List<Operation<Item>> { new() { op = "replace", path = "/name", value = expectedDescription } },
            new DefaultContractResolver());
        
        //Act
        var result = controller.Update(patchDocument, expectedItem.Id);
        expectedItem.Description = "something diff";

        var okObjectResult = result.Should().BeOfTypeAndReturn<OkObjectResult>();
        okObjectResult.Value.Should().BeEquivalentTo(expectedItem);
    }

  
}