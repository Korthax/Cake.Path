using System;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Moq;
using Xunit;

namespace Cake.Path.UnitTests.GivenAnItem.ToRemoveFromThePath
{
    public class WhenThePathIsNull
    {
        [Fact]
        public void ThenNothingIsRemovedFromThePath()
        {
            var environmentWrapper = new Mock<IEnvironmentWrapper>();
            environmentWrapper.Setup(x => x.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Process, string.Empty)).Returns(string.Empty);

            var subject = new Path(new NullLog(), environmentWrapper.Object);
            subject.Remove(new DirectoryPath("test"), new PathSettings { Target = PathTarget.Process });

            environmentWrapper.Verify(x => x.SetEnvironmentVariable(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EnvironmentVariableTarget>()), Times.Never);
        }
    }
}