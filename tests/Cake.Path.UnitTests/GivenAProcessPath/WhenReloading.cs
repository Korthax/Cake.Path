using Cake.Core.Diagnostics;
using Moq;
using NUnit.Framework;

namespace Cake.Path.UnitTests.GivenAProcessPath
{
#if (NET45)
    [TestFixture]
    public class WhenReloading
    {
        [Test]
        public void ThenThePathIsSetToTheMachineAndUserPath()
        {
            var environmentWrapper = new Mock<IEnvironmentWrapper>();
            environmentWrapper.Setup(x => x.GetEnvironmentVariable("PATH", PathTarget.User, string.Empty)).Returns("us;er");
            environmentWrapper.Setup(x => x.GetEnvironmentVariable("PATH", PathTarget.Machine, string.Empty)).Returns("mach;ine");

            var subject = new Path(new NullLog(), environmentWrapper.Object);
            subject.Reload();

            environmentWrapper.Verify(x => x.SetEnvironmentVariable("PATH", "mach;ine;us;er", PathTarget.Process), Times.Once);
        }
    }
#else
    [TestFixture]
    public class WhenReloading
    {
        [Test]
        public void ThenThePathIsSetToTheMachineAndUserPath()
        {
            var environmentWrapper = new Mock<IEnvironmentWrapper>();
            environmentWrapper.Setup(x => x.GetEnvironmentVariable("PATH", PathTarget.User, string.Empty)).Returns("us;er");
            environmentWrapper.Setup(x => x.GetEnvironmentVariable("PATH", PathTarget.Machine, string.Empty)).Returns("mach;ine");

            var subject = new Path(new NullLog(), environmentWrapper.Object);
            subject.Reload();

            environmentWrapper.Verify(x => x.SetEnvironmentVariable("PATH", "us;er", PathTarget.Process), Times.Once);
        }
    }
#endif
}