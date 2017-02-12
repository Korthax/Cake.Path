using System;
using Cake.Core.Diagnostics;
using Moq;
using Xunit;

namespace Cake.Path.UnitTests.GivenAnItem.ToRemoveFromThePath
{
    public class WhenTheItemExistsInThePath
    {
        [Fact]
        public void ThenTheItemIsRemovedFromThePath()
        {
            var environmentWrapper = new Mock<IEnvironmentWrapper>();
            environmentWrapper.Setup(x => x.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Machine, string.Empty)).Returns("test;test2");

            var subject = new Path(new NullLog(), environmentWrapper.Object);
            subject.Remove("test", new PathSettings { Target = PathTarget.Machine });

            environmentWrapper.Verify(x => x.SetEnvironmentVariable("PATH", "test2", EnvironmentVariableTarget.Machine), Times.Once);
        }
    }
}