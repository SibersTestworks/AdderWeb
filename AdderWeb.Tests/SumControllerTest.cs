using AdderWeb.API.Controllers;
using AdderWeb.Domain.Contracts;
using AdderWeb.Domain.Entities;
using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NuGet.Protocol;
using System.Text.Json;
using Xunit;

namespace AdderWeb.Tests;

public class SumControllerTest
{
    [Fact]
    public async Task Create_ReturnsJsonResultWithSum()
    {
        // Arrange
        var mockSumService = new Mock<IRepository<Sum>>();
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
        var controller = new SumController(mockSumService.Object);

        // Act
        var result = await controller.Create(sum) as JsonHttpResult<Sum>;
        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedSum, result.Value);
    }
}
