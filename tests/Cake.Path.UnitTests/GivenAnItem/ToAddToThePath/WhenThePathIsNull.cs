using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Moq;
using Xunit;

namespace Cake.Path.UnitTests.GivenAnItem.ToAddToThePath
{
    public class WhenThePathIsNull
    {
        [Fact]
        public void ThenANewPathIsAddedWithTheValue()
        {
            var environmentWrapper = new Mock<IEnvironmentWrapper>();
            environmentWrapper.Setup(x => x.GetEnvironmentVariable("PATH", string.Empty)).Returns(string.Empty);

            var subject = new Path(new NullLog(), environmentWrapper.Object);
            subject.Add(new DirectoryPath("test"));

            environmentWrapper.Verify(x => x.SetEnvironmentVariable("PATH", "test"), Times.Once);
        }
    }
}