using System;
using Cake.Core.Diagnostics;
using Moq;
using Xunit;

namespace Cake.Path.UnitTests.GivenAProcessPath
{
    public class WhenReloading
    {
        [Fact]
        public void ThenThePathIsSetToTheMachineAndUserPath()
        {
            var environmentWrapper = new Mock<IEnvironmentWrapper>();
            environmentWrapper.Setup(x => x.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.User, string.Empty)).Returns("us;er");
            environmentWrapper.Setup(x => x.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Machine, string.Empty)).Returns("mach;ine");

            var subject = new Path(new NullLog(), environmentWrapper.Object);
            subject.Reload();

            environmentWrapper.Verify(x => x.SetEnvironmentVariable("PATH", "mach;ine;us;er", EnvironmentVariableTarget.Process), Times.Once);
        }
    }
}