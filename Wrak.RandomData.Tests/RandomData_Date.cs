namespace Wrak.RandomData.Tests;

public class RandomData_Date
{
    [Theory]
    [InlineData(1995, 2035)]
    [InlineData(2000, 2020)]
    public void ShouldReturnDateTimeWithinRange(int minYear, int maxYear)
    {
        DateTime result = RandomData.Date(minYear, maxYear);
        Assert.InRange(result.Year, minYear, maxYear);
    }
}