namespace Wrak.RandomData.Tests
{
    public class RandomData_Long
    {
        [Theory]
        [InlineData(0L, 100L)]
        [InlineData(-50L, 50L)]
        public void ShouldReturnLongWithinRange(long minValue, long maxValue)
        {
            long result = RandomData.Int(minValue, maxValue);
            Assert.InRange(result, minValue, maxValue);
        }
    }
}
