namespace Wrak.RandomData;

public static partial class RandomDataExtensions
{
    private static readonly Random _rnd = new();

    public static bool Bool(this IRandomData _)
    {
        return _rnd.Next(0, 2) > 0;
    }

    public static DateTime DateTime(this IRandomData _, int minYear = 1995, int maxYear = 2035)
    {
        if (minYear < System.DateTime.MinValue.Year)
            throw new ArgumentOutOfRangeException($"{nameof(minYear)} is out of range.");
        if (maxYear > System.DateTime.MaxValue.Year)
            throw new ArgumentOutOfRangeException($"{nameof(maxYear)} is out of range.");
        if (minYear > maxYear)
            throw new ArgumentException($"{nameof(minYear)} must be less than or equal to {nameof(maxYear)}");

        var startYear = new DateTime(minYear, 1, 1);
        var endYear = new DateTime(maxYear, 1, 1);
        var dayRange = (endYear - startYear).Days;
        var randomDate = startYear.AddDays(_rnd.Next(dayRange));
        var randomTime = new TimeSpan(_rnd.Next(0, 24), _rnd.Next(0, 60), _rnd.Next(0, 60));

        return randomDate.Add(randomTime);
    }

    public static DateOnly DateOnly(this IRandomData _, int minYear = 1995, int maxYear = 2035)
    {
        if (minYear < System.DateOnly.MinValue.Year)
            throw new ArgumentOutOfRangeException($"{nameof(minYear)} is out of range.");
        if (maxYear > System.DateOnly.MaxValue.Year)
            throw new ArgumentOutOfRangeException($"{nameof(maxYear)} is out of range.");
        if (minYear > maxYear)
            throw new ArgumentException($"{nameof(minYear)} must be less than or equal to {nameof(maxYear)}");

        var start = new DateOnly(minYear, 1, 1);
        var end = new DateOnly(maxYear, 1, 1);
        var dayRange = end.DayNumber - start.DayNumber;
        var randomDay = _rnd.Next(dayRange);
        return start.AddDays(randomDay);
    }

    public static TimeOnly TimeOnly(this IRandomData _, int minHour = 0, int maxHour = 23)
    {
        if (minHour < 0 || minHour > 23)
            throw new ArgumentOutOfRangeException(nameof(minHour));
        if (maxHour < 0 || maxHour > 23)
            throw new ArgumentOutOfRangeException(nameof(maxHour));
        if (minHour > maxHour)
            throw new ArgumentException($"{nameof(minHour)} must be less than or equal to {nameof(maxHour)}");

        int hour = _rnd.Next(minHour, maxHour + 1);
        int minute = _rnd.Next(0, 60);
        int second = _rnd.Next(0, 60);
        int millisecond = _rnd.Next(0, 1000);
        return new TimeOnly(hour, minute, second, millisecond);
    }

    public static TimeSpan TimeSpan(this IRandomData _, long minTicks = 0, long maxTicks = System.TimeSpan.TicksPerDay * 365)
    {
        if (minTicks < 0)
            throw new ArgumentOutOfRangeException($"{nameof(minTicks)} must be non-negative.");
        if (maxTicks < 0)
            throw new ArgumentOutOfRangeException($"{nameof(maxTicks)} must be non-negative.");
        if (minTicks > maxTicks)
            throw new ArgumentException($"{nameof(minTicks)} must be less than or equal to {nameof(maxTicks)}");

        long ticks = _rnd.NextInt64(minTicks, maxTicks);
        return new TimeSpan(ticks);
    }

    public static int Int(this IRandomData _, int minValue = 0, int maxValue = 100_000)
    {
        if (minValue > maxValue)
            throw new ArgumentException($"{nameof(minValue)} must be less than or equal to {nameof(maxValue)}");

        return _rnd.Next(minValue, maxValue);
    }

    public static long Long(this IRandomData _, long minValue = 0, long maxValue = 100_000)
    {
        if (minValue > maxValue)
            throw new ArgumentException($"{nameof(minValue)} must be less than or equal to {nameof(maxValue)}");

        return _rnd.NextInt64(minValue, maxValue);
    }

    public static double Double(this IRandomData _, double minValue = 0, double maxValue = 100_000)
    {
        if (minValue > maxValue)
            throw new ArgumentException($"{nameof(minValue)} must be less than or equal to {nameof(maxValue)}");

        return (_rnd.NextDouble() * (maxValue - minValue) + minValue);
    }

    public static decimal Decimal(this IRandomData _, decimal minValue = 0m, decimal maxValue = 100_000m)
    {
        if (minValue > maxValue)
            throw new ArgumentException($"{nameof(minValue)} must be less than or equal to {nameof(maxValue)}");

        return (decimal)(_rnd.NextDouble() * (double)(maxValue - minValue) + (double)minValue);
    }

    public static char Char(this IRandomData random)
    {
        return random.String(1)[0];
    }

    public static string String(this IRandomData _, int? length = null)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+";

        // NOTE: Setting minValue to zero will potentially return an empty string.
        length = length ?? _rnd.Next(1, chars.Length);

        return new string(Enumerable.Repeat(chars, length.Value).Select(s => s[_rnd.Next(s.Length)]).ToArray());
    }

    public static T Enumeration<T>(this IRandomData _) where T : struct, IConvertible
    {
        if (!typeof(T).IsEnum)
            throw new ArgumentException("T must be an enum");

        var vals = (T[])Enum.GetValues(typeof(T));
        var index = _rnd.Next(vals.Length - 1);
        return vals[index];
    }
}