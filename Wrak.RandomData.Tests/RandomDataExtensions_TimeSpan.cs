namespace Wrak.RandomData.Tests;

public class RandomDataExtensions_TimeSpan
{
    [Theory]
    [InlineData(TimeSpan.TicksPerSecond, TimeSpan.TicksPerSecond * 2)]
    [InlineData(TimeSpan.TicksPerMinute, TimeSpan.TicksPerMinute * 5)]
    [InlineData(TimeSpan.TicksPerHour, TimeSpan.TicksPerHour * 10)]
    public void ShouldReturnTimeSpanWithinRange(long minTicks, long maxTicks)
    {
        var ts = RandomData.As.TimeSpan(minTicks, maxTicks);
        Assert.InRange(ts.Ticks, minTicks, maxTicks);
    }
}