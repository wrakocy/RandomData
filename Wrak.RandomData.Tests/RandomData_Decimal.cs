namespace Wrak.RandomData.Tests
{
    public class RandomData_Decimal
    {
        [Theory]
        [InlineData(0.0, 100.0)]
        [InlineData(-50.0, 50.0)]
        public void ShouldReturnDecimalWithinRange(decimal minValue, decimal maxValue)
        {
            decimal result = RandomData.Decimal(minValue, maxValue);
            Assert.InRange(result, minValue, maxValue);
        }
    }
}
