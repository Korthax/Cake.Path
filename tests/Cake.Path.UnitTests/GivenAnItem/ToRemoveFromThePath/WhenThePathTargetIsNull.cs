using System;
using Cake.Core.Diagnostics;
using Moq;
using Xunit;

namespace Cake.Path.UnitTests.GivenAnItem.ToRemoveFromThePath
{
    public class WhenThePathTargetIsNull
    {
        [Fact]
        public void ThenTheEnvironmentVariableTargetIsDefaultedToUser()
        {
            var environmentWrapper = new Mock<IEnvironmentWrapper>();
            environmentWrapper.Setup(x => x.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.User, string.Empty)).Returns("test;test2");

            var subject = new Path(new NullLog(), environmentWrapper.Object);
            subject.Remove("test", new PathSettings { Target = null });

            environmentWrapper.Verify(x => x.SetEnvironmentVariable("PATH", "test2", EnvironmentVariableTarget.User), Times.Once);
        }
    }
}