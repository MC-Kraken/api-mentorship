using api.Controllers;
using api.Db;
using api.Requests;
using AutoBogus;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.AutoMock;
using TestProject1.Extensions;
using Xunit;

namespace TestProject1;

public class ItemsController_should
{
    [Fact]
    public void GetAllItems()
    {
        var mocker = new AutoMocker();
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
        
        mocker.Setup<IMediator, Task<IList<Item>>>(mm =>
            mm.Send(It.IsAny<GetItemsRequest>(), new CancellationToken())!
        )
        .ReturnsAsync(existingItems);
        
        var options = new DbContextOptionsBuilder<ItemContext>().UseInMemoryDatabase(AutoFaker.Generate<string>())
            .Options;
        var context = new ItemContext(options);
        context.Items.AddRange(existingItems);
        context.SaveChanges();
        var controller = mocker.CreateInstance<ItemsController>();

        // Act
        var result = controller.Get();

        //Assert
        var okObjectResult = result.Should().BeOfTypeAndReturn<OkObjectResult>();
        okObjectResult.Value.Should().BeEquivalentTo(existingItems);
    }
    
    // [Fact]
    // public void GetById()
    // {
    //     var mocker = new AutoMocker();
    //     // Arrange
    //     var existingItems = new List<Item>
    //     {
    //         new()
    //         {
    //             Id = Guid.NewGuid(),
    //             Name = "Item 1",
    //             Description = "Pick up groceries"
    //         },
    //         new()
    //         {
    //             Id = Guid.NewGuid(),
    //             Name = "Item 2",
    //             Description = "Go to bank"
    //         },
    //         new()
    //         {
    //             Id = Guid.NewGuid(),
    //             Name = "Item 3",
    //             Description = "Go to post office"
    //         }
    //     };
    //     var expectedItem = existingItems[0];
    //     var options = new DbContextOptionsBuilder<ItemContext>().UseInMemoryDatabase(AutoFaker.Generate<string>())
    //         .Options;
    //     mocker
    //         .Setup<IMediator, Task<IList<Item>>>(mm =>
    //             mm.Send(It.IsAny<GetItemRequest>(), new CancellationToken())!
    //         )
    //         .ReturnsAsync(expectedItem);
    //     var context = new ItemContext(options);
    //     context.Items.AddRange(existingItems);
    //     context.SaveChanges();
    //     var controller = mocker;
    //
    //     // Act
    //     var result = controller.GetById(expectedItem.Id);
    //
    //     //Assert
    //     var okObjectResult = result.Should().BeOfTypeAndReturn<OkObjectResult>();
    //     okObjectResult.Value.Should().Be(expectedItem);
    // }

    // [Fact]
    // public void UpdateAllItems()
    // {
    //     var options = new DbContextOptionsBuilder<ItemContext>().UseInMemoryDatabase(AutoFaker.Generate<string>())
    //         .Options;
    //     var context = new ItemContext(options);
    //     var expectedItem = AutoFaker.Generate<Item>();
    //     context.Add(expectedItem);
    //     context.SaveChanges();
    //     var controller = new ItemsController(context);
    //     var expectedDescription = "TEST NAME";
    //
    //     var patchDocument = new JsonPatchDocument<Item>(
    //         new List<Operation<Item>> { new() { op = "replace", path = "/name", value = expectedDescription } },
    //         new DefaultContractResolver());
    //     
    //     //Act
    //     var result = controller.Update(patchDocument, expectedItem.Id);
    //     expectedItem.Description = "something diff";
    //
    //     var okObjectResult = result.Should().BeOfTypeAndReturn<OkObjectResult>();
    //     okObjectResult.Value.Should().BeEquivalentTo(expectedItem);
    // }
}