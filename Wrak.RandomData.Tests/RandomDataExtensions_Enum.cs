namespace Wrak.RandomData.Tests;

public class RandomDataExtensions_Enum
{
    [Fact]
    public void ShouldReturnValidEnumValue()
    {
        var result = RandomData.As.Enum<DayOfWeek>();
        Assert.IsType<DayOfWeek>(result);
    }
}

