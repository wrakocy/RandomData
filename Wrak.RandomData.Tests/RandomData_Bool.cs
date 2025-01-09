namespace Wrak.RandomData.Tests
{
    public class RandomData_Bool
    {
        [Fact]
        public void ShouldReturnBoolean()
        {
            bool result = RandomData.Bool();
            Assert.IsType<bool>(result);
        }
    }
}