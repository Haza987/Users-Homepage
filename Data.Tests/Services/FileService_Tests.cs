using Data.Interfaces;
using Domain.Models;
using Moq;

namespace Data.Tests.Services;

public class FileService_Tests
{
    private readonly Mock<IFileService> _fileServiceMock;
    private readonly IFileService _fileService;

    public FileService_Tests()
    {
        _fileServiceMock = new Mock<IFileService>();
        _fileService = _fileServiceMock.Object;
    }

    [Fact]
    public void SaveListToFile_ShouldReturnTrue_WhenContentIsSaved()
    {
        // Arrange
        var contacts = new List<ContactItem>();
        _fileServiceMock.Setup(x => x.SaveListToFile(It.IsAny<List<ContactItem>>())).Returns(true);

        // Act
        bool result = _fileService.SaveListToFile(contacts);
        // Assert
        Assert.True(result);
    }

    [Fact]
    public void LoadListFromFile_ShouldReturnList_WhenContentIsLoaded()
    {
        // Arrange
        var contacts = new List<ContactItem>();
        _fileServiceMock.Setup(x => x.LoadListFromFile()).Returns(contacts);
        // Act
        var result = _fileService.LoadListFromFile();
        // Assert
        Assert.Equal(contacts, result);
    }
}
