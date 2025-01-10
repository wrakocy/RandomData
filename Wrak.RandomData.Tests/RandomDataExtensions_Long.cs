namespace Wrak.RandomData.Tests;

public class RandomDataExtensions_Long
{
    [Theory]
    [InlineData(0L, 100L)]
    [InlineData(-50L, 50L)]
    public void ShouldReturnLongWithinRange(long minValue, long maxValue)
    {
        long result = RandomData.As.Long(minValue, maxValue);
        Assert.InRange(result, minValue, maxValue);
    }
}
