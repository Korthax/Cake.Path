using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Moq;
using NUnit.Framework;

namespace Cake.Path.UnitTests.GivenAnItem.ToRemoveFromThePath
{
    public class WhenThePathIsNull
    {
        [Test]
        public void ThenNothingIsRemovedFromThePath()
        {
            var environmentWrapper = new Mock<IEnvironmentWrapper>();
            environmentWrapper.Setup(x => x.GetEnvironmentVariable("PATH", PathTarget.Process, string.Empty)).Returns(string.Empty);

            var subject = new Path(new NullLog(), environmentWrapper.Object);
            subject.Remove(new DirectoryPath("test"), new PathSettings { Target = PathTarget.Process });

            environmentWrapper.Verify(x => x.SetEnvironmentVariable(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<PathTarget>()), Times.Never);
        }
    }
}