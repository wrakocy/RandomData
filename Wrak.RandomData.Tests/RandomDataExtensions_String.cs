namespace Wrak.RandomData.Tests;

public class RandomDataExtensions_String
{
    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    public void ShouldReturnStringOfSpecifiedLength(int length)
    {
        string result = RandomData.As.String(length);
        Assert.Equal(length, result.Length);
    }
}
