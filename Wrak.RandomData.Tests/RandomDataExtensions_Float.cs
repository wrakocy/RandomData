namespace Wrak.RandomData.Tests;

public class RandomDataExtensions_Float
{
    [Theory]
    [InlineData(0f, 100f)]
    [InlineData(-50f, 50f)]
    public void ShouldReturnFloatWithinRange(float minValue, float maxValue)
    {
        float result = RandomData.As.Float(minValue, maxValue);
        Assert.InRange(result, minValue, maxValue);
    }

    [Fact]
    public void ShouldThrowWhenMinValueGreaterThanMaxValue()
    {
        Assert.Throws<ArgumentException>(() => RandomData.As.Float(100f, 0f));
    }
}
