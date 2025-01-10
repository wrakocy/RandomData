namespace Wrak.RandomData.Tests;

public class RandomDataExtensions_Enumeration
{
    [Fact]
    public void ShouldReturnValidEnumValue()
    {
        var result = RandomData.As.Enumeration<DayOfWeek>();
        Assert.IsType<DayOfWeek>(result);
    }
}

