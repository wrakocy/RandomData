namespace Wrak.RandomData.Tests
{
    public class RandomData_Int
    {
        [Theory]
        [InlineData(0, 100)]
        [InlineData(-50, 50)]
        public void ShouldReturnIntWithinRange(int minValue, int maxValue)
        {
            int result = RandomData.Int(minValue, maxValue);
            Assert.InRange(result, minValue, maxValue);
        }
    }
}
