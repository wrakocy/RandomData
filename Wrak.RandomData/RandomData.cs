namespace Wrak.RandomData;

public interface IRandomData
{
}

public class RandomData : IRandomData
{
    public static IRandomData As { get; } = new RandomData();

    private RandomData() { }
}