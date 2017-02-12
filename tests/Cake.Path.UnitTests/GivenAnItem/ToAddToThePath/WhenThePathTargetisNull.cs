using System;
using Cake.Core.Diagnostics;
using Moq;
using Xunit;

namespace Cake.Path.UnitTests.GivenAnItem.ToAddToThePath
{
    public class WhenThePathTargetisNull
    {
        [Fact]
        public void ThenTheEnvironmentVariableTargetIsDefaultedToUser()
        {
            var environmentWrapper = new Mock<IEnvironmentWrapper>();
            environmentWrapper.Setup(x => x.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.User, string.Empty)).Returns("test;test2");

            var subject = new Path(new NullLog(), environmentWrapper.Object);
            subject.Add("value", new PathSettings { Target = null });

            environmentWrapper.Verify(x => x.SetEnvironmentVariable("PATH", "test;test2;value", EnvironmentVariableTarget.User), Times.Once);
        }
    }
}