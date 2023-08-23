using AdderWeb.API.Controllers;
using AdderWeb.Domain.Contracts;
using AdderWeb.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace AdderWeb.Tests;

public class SumControllerTest
{
    [Fact]
    public async Task Create_ReturnsJsonResultWithSum()
    {
        // Arrange
        var mockSumService = new Mock<IRepository<Sum>>();
        var controller = new SumController(mockSumService.Object);
        var sum = new Sum { Id=new(), First = 1, Second = 2, Result=0 };
        var expectedSum = new Sum
        {
            Id=new(),
            First = sum.First,
            Second = sum.Second,
            Result = sum.First + sum.Second
        };

        mockSumService
            .Setup(service => service.AddAsync(It.IsAny<Sum>(), default))
            .ReturnsAsync(expectedSum);

        // Act
        var result = await controller.Create(sum) as JsonResult;

        // Assert
        Assert.NotNull(result);
        var sumResult = result.Value as Sum;
        Assert.NotNull(sumResult);
        Assert.Equal(sum.First + sum.Second, sumResult.Result);
    }
}
