namespace Wrak.RandomData.Tests;

public class RandomData_Extend
{
    [Fact]
    public void WithStaticMethod()
    {
        var result = RandomData.As.FiveLetterWord();
        Assert.Equal(5, result.Length);
    }
}

public static partial class RandomDataExtensions
{
    public static string FiveLetterWord(this IRandomData random) => random.String(5);
}
