namespace Wrak.RandomData.Tests;

public class RandomDataExtensions_Date
{
    [Theory]
    [InlineData(1995, 2035)]
    [InlineData(2000, 2020)]
    public void ShouldReturnDateTimeWithinRange(int minYear, int maxYear)
    {
        var dt = RandomData.As.Date(minYear, maxYear);
        Assert.InRange(dt.Year, minYear, maxYear);
    }

    [Fact]
    public void ShouldReturnDateTimeWithoutDefaultTime()
    {
        for (int i = 0; i < 100; i++)
        {
            var dt = RandomData.As.Date();
            if (dt.TimeOfDay > TimeSpan.Zero) return;
        }

        Assert.Fail("All generated dates had a default time.");
    }
}