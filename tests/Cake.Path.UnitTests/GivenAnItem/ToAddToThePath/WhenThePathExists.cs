using Cake.Core.Diagnostics;
using Moq;
using Xunit;

namespace Cake.Path.UnitTests.GivenAnItem.ToAddToThePath
{
    public class WhenThePathExists
    {
        [Fact]
        public void ThenTheItemIsAddedToTheEndOfThePath()
        {
            var environmentWrapper = new Mock<IEnvironmentWrapper>();
            environmentWrapper.Setup(x => x.GetEnvironmentVariable("PATH", string.Empty)).Returns("test;test2");

            var subject = new Path(new NullLog(), environmentWrapper.Object);
            subject.Add("value");

            environmentWrapper.Verify(x => x.SetEnvironmentVariable("PATH", "test;test2;value"), Times.Once);
        }
    }
}