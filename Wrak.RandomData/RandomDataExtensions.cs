namespace Wrak.RandomData;

public static partial class RandomDataExtensions
{
    private static readonly Random _rnd = new();

    public static bool Bool(this IRandomData random)
    {
        return _rnd.Next(0, 2) > 0;
    }

    public static DateTime Date(this IRandomData random, int minYear = 1995, int maxYear = 2035)
    {
        var start = new DateTime(minYear, 1, 1);
        var end = new DateTime(maxYear, 1, 1);
        var range = (end - start).Days;

        return start.AddDays(_rnd.Next(range));
    }

    public static int Int(this IRandomData random, int minValue = 0, int maxValue = int.MaxValue)
    {
        return _rnd.Next(minValue, maxValue);
    }

    public static long Long(this IRandomData random, long minValue = 0, long maxValue = long.MaxValue)
    {
        return _rnd.NextInt64(minValue, maxValue);
    }

    public static double Double(this IRandomData random, double minValue = 0, double maxValue = double.MaxValue)
    {
        return (_rnd.NextDouble() * (maxValue - minValue) + minValue);
    }

    public static decimal Decimal(this IRandomData random, decimal minValue = 0m, decimal maxValue = decimal.MaxValue)
    {
        return (decimal)(_rnd.NextDouble() * (double)(maxValue - minValue) + (double)minValue);
    }

    public static char Char(this IRandomData random)
    {
        return random.String(1)[0];
    }

    public static string String(this IRandomData random, int? length = null)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+";

        // Setting minValue to zero will allow this function to potentially return an empty string.
        length = length ?? _rnd.Next(1, chars.Length);

        return new string(Enumerable.Repeat(chars, length.Value).Select(s => s[_rnd.Next(s.Length)]).ToArray());
    }

    public static T Enumeration<T>(this IRandomData random) where T : struct, IConvertible
    {
        if (!typeof(T).IsEnum)
            throw new ArgumentException("T must be an enum");

        var vals = (T[])Enum.GetValues(typeof(T));
        var index = _rnd.Next(vals.Length - 1);
        return (T)vals[index];
    }
}