using Cake.Core.Diagnostics;
using Moq;
using NUnit.Framework;

namespace Cake.Path.UnitTests.GivenAProcessPath
{
    [TestFixture]
    public class WhenFetching
    {
        [Test]
        public void ThenTheCorrectPathIsReturned()
        {
            var environmentWrapper = new Mock<IEnvironmentWrapper>();
            environmentWrapper.Setup(x => x.GetEnvironmentVariable("PATH", PathTarget.User, string.Empty)).Returns("us;er");
            environmentWrapper.Setup(x => x.GetEnvironmentVariable("PATH", PathTarget.Machine, string.Empty)).Returns("mach;ine");
            environmentWrapper.Setup(x => x.GetEnvironmentVariable("PATH", PathTarget.Process, string.Empty)).Returns("pro;cess");

            var subject = new PathWrapper(new NullLog(), environmentWrapper.Object);
            var result = subject.Get(new PathSettings { Target = PathTarget.Process });

            Assert.That(result, Is.EqualTo("pro;cess"));
        }
    }
}