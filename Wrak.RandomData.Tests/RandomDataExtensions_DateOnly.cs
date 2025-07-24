namespace Wrak.RandomData.Tests;

public class RandomDataExtensions_DateOnly
{
    [Theory]
    [InlineData(1995, 2035)]
    [InlineData(2000, 2020)]
    public void ShouldReturnDateWithinRange(int minYear, int maxYear)
    {
        var date = RandomData.As.DateOnly(minYear, maxYear);
        Assert.InRange(date.Year, minYear, maxYear);
    }
}