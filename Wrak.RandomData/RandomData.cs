namespace Wrak.RandomData;

public static partial class RandomData
{
    #region Fields

    private static readonly Random _rnd = new();

    #endregion

    #region Public methods

    public static bool Bool()
    {
        var result = _rnd.Next(0, 2) > 0;
        return result;
    }

    public static DateTime Date(int minYear = 1995, int maxYear = 2035)
    {
        DateTime start = new(minYear, 1, 1);
        DateTime end = new(maxYear, 1, 1);
        int range = (end - start).Days;
        return start.AddDays(_rnd.Next(range));
    }

    public static int Int(int minValue = 0, int maxValue = int.MaxValue)
    {
        return _rnd.Next(minValue, maxValue);
    }

    public static long Int(long minValue = 0, long maxValue = long.MaxValue)
    {
        return _rnd.NextInt64(minValue, maxValue);
    }

    public static double Double(double minValue = 0, double maxValue = double.MaxValue)
    {
        return (_rnd.NextDouble() * (maxValue - minValue) + minValue);
    }

    public static decimal Decimal(decimal minValue = 0m, decimal maxValue = decimal.MaxValue)
    {
        return (decimal)(_rnd.NextDouble() * (double)(maxValue - minValue) + (double)minValue);
    }

    public static string String(int? length = null)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+";

        // Setting minValue to zero will allow this function to potentially return an empty string.
        length = length ?? _rnd.Next(1, chars.Length);

        return new string(Enumerable.Repeat(chars, length.Value).Select(s => s[_rnd.Next(s.Length)]).ToArray());
    }

    public static T Enumeration<T>() where T : struct, IConvertible
    {
        if (!typeof(T).IsEnum)
            throw new ArgumentException("T must be an enum");

        var vals = (T[])Enum.GetValues(typeof(T));
        var index = _rnd.Next(vals.Length - 1);
        return (T)vals[index];
    }

    #endregion
}