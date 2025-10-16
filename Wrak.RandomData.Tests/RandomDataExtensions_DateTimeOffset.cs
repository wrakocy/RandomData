namespace Wrak.RandomData.Tests;

public class RandomDataExtensions_DateTimeOffset
{
    [Theory]
    [InlineData(1995, 2035)]
    [InlineData(2000, 2020)]
    public void ShouldReturnDateTimeWithinRange(int minYear, int maxYear)
    {
        var dto = RandomData.As.DateTimeOffset(minYear, maxYear);
        Assert.InRange(dto.Year, minYear, maxYear);
    }

    [Fact]
    public void ShouldReturnAtLeastOneDateTimeWithoutDefaultTime()
    {
        for (int i = 0; i < 100; i++)
        {
            var dt = RandomData.As.DateTimeOffset();
            if (dt.TimeOfDay > TimeSpan.Zero) return;
        }

        Assert.Fail("All generated date times had default times.");
    }

    [Fact]
    public void ShouldReturnAtLeastOneDateTimeWithoutDefaultOffset()
    {
        for (int i = 0; i < 100; i++)
        {
            var dt = RandomData.As.DateTimeOffset();
            if (dt.Offset > TimeSpan.Zero) return;
        }

        Assert.Fail("All generated date times had default offsets.");
    }
}