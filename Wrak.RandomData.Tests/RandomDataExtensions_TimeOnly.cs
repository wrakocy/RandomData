namespace Wrak.RandomData.Tests;

public class RandomDataExtensions_TimeOnly
{
    [Theory]
    [InlineData(2, 12)]
    [InlineData(1, 23)]
    [InlineData(5, 5)]
    public void ShouldReturnTimeWithinRange(int minHour, int maxHour)
    {
        var time = RandomData.As.TimeOnly(minHour, maxHour);
        Assert.InRange(time.Hour, minHour, maxHour);
    }
}