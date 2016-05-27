using TDiary.ViewModel;
using Xunit;

namespace MyFirstDotNetCoreTests
{
    public class Class1
    {
        [Fact]
        public void PassingTest()
        {
            var sut = new HomeViewModel("Test");
            Assert.Equal("Test", sut.Title);
        }
    }
}