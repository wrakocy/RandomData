namespace Wrak.RandomData.Tests;

public class RandomDataExtensions_Int
{
    [Theory]
    [InlineData(0, 100)]
    [InlineData(-50, 50)]
    public void ShouldReturnIntWithinRange(int minValue, int maxValue)
    {
        int result = RandomData.As.Int(minValue, maxValue);
        Assert.InRange(result, minValue, maxValue);
    }
}
