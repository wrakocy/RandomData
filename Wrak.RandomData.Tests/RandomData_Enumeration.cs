namespace Wrak.RandomData.Tests
{
    public class RandomData_Enumeration
    {
        [Fact]
        public void ShouldReturnValidEnumValue()
        {
            var result = RandomData.Enumeration<DayOfWeek>();
            Assert.IsType<DayOfWeek>(result);
        }
    }
}
