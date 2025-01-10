namespace Wrak.RandomData.Tests;

public class RandomDataExtensions_Char
{
    [Fact]
    public void ShouldReturnSingleCharacter()
    {
        // Act
        var result = RandomData.As.Char();

        // Assert
        Assert.True(char.IsLetterOrDigit(result) || "!@#$%^&*()_+".Contains(result));
    }
}
