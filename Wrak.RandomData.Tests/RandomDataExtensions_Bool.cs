namespace Wrak.RandomData.Tests;

public class RandomDataExtensions_Bool
{
    [Fact]
    public void ShouldReturnBoolean()
    {
        bool result = RandomData.As.Bool();
        Assert.IsType<bool>(result);
    }
}