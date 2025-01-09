namespace Wrak.RandomData.Tests
{
    public class RandomData_Double
    {
        [Theory]
        [InlineData(0.0, 100.0)]
        [InlineData(-50.0, 50.0)]
        public void ShouldReturnDoubleWithinRange(double minValue, double maxValue)
        {
            double result = RandomData.Double(minValue, maxValue);
            Assert.InRange(result, minValue, maxValue);
        }
    }
}
