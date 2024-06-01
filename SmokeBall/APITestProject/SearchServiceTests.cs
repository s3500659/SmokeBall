using API;
using Models;
using Moq;
using Xunit;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

public class SearchServiceTests
{
    private readonly SearchService _searchService;
    private readonly Mock<IFileReader> _mockFileReader;
    private readonly Mock<IStringBuilderWrapper> _mockStringBuilder;
    private readonly Mock<IRegexMatcher> _mockRegexMatcher;
    private readonly Mock<ILogger<SearchService>> _mockLogger;

    public SearchServiceTests()
    {
        _mockFileReader = new Mock<IFileReader>();
        _mockStringBuilder = new Mock<IStringBuilderWrapper>();
        _mockRegexMatcher = new Mock<IRegexMatcher>();
        _mockLogger = new Mock<ILogger<SearchService>>();

        _searchService = new SearchService(_mockFileReader.Object, _mockStringBuilder.Object, _mockRegexMatcher.Object, _mockLogger.Object);
    }

    [Fact]
    public void Search_FileNotFound_ReturnsErrorMessage()
    {
        // Arrange
        _mockFileReader.Setup(fr => fr.ReadAllText(It.IsAny<string>())).Throws(new FileNotFoundException());

        var searchInput = new SearchInputModel { Engine = SearchEngineType.Google };

        // Act
        var result = _searchService.Search(searchInput, "testSearchResult.txt", "www.smokeball.com.au");

        // Assert
        Assert.Equal("Search result file not found.", result);
    }

    [Fact]
    public void Search_ErrorReadingFile_ReturnsErrorMessage()
    {
        // Arrange
        _mockFileReader.Setup(fr => fr.ReadAllText(It.IsAny<string>())).Throws(new Exception());

        var searchInput = new SearchInputModel { Engine = SearchEngineType.Google };

        // Act
        var result = _searchService.Search(searchInput, "testSearchResult.txt", "www.smokeball.com.au");

        // Assert
        Assert.Contains("Error reading search result file.", result);
    }

    [Fact]
    public void Search_NotUsingGoogle_ThrowsError()
    {
        // Arrange
        _mockFileReader.Setup(fr => fr.ReadAllText(It.IsAny<string>())).Throws(new NotImplementedException());

        var searchInput = new SearchInputModel { Engine = SearchEngineType.Bing };

        Assert.Throws<NotImplementedException>(() => _searchService.Search(searchInput, "testSearchResult.txt", "www.smokeball.com.au"));
    }


    [Fact]
    public void Search_Google_IndexFound()
    {
        // Arrange
        var searchInput = new SearchInputModel { Engine = SearchEngineType.Google };

        var fileReader = new FileReader();
        var sb = new StringBuilderWrapper();
        var regexMatcher = new RegexMatcher();
        var searchService = new SearchService(fileReader, sb, regexMatcher, _mockLogger.Object);


        // Act
        var result = searchService.Search(searchInput, @"testSearchResult.txt", "www.smokeball.com.au");

        // Assert
        Assert.Equal("1, 31", result);
    }

    [Fact]
    public void Search_Google_IndexNotFound()
    {
        // Arrange
        var searchInput = new SearchInputModel { Engine = SearchEngineType.Google };

        var fileReader = new FileReader();
        var sb = new StringBuilderWrapper();
        var regexMatcher = new RegexMatcher();
        var searchService = new SearchService(fileReader, sb, regexMatcher, _mockLogger.Object);


        // Act
        var result = searchService.Search(searchInput, @"testSearchResult.txt", "www.vinh.com.au");

        // Assert
        Assert.Equal("0", result);
    }






}
