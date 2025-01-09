namespace Wrak.RandomData.Tests
{
    public class RandomData_String
    {
        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        public void ShouldReturnStringOfSpecifiedLength(int length)
        {
            string result = RandomData.String(length);
            Assert.Equal(length, result.Length);
        }
    }
}
