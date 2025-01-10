namespace Wrak.RandomData.Tests;

public class RandomDataExtensions_Decimal
{
    [Theory]
    [InlineData(0.0, 100.0)]
    [InlineData(-50.0, 50.0)]
    public void ShouldReturnDecimalWithinRange(decimal minValue, decimal maxValue)
    {
        decimal result = RandomData.As.Decimal(minValue, maxValue);
        Assert.InRange(result, minValue, maxValue);
    }
}