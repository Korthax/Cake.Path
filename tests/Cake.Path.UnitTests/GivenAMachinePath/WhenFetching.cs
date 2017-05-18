using Cake.Core.Diagnostics;
using Moq;
using NUnit.Framework;

namespace Cake.Path.UnitTests.GivenAMachinePath
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

            var subject = new PathWrapper(new NullLog(), environmentWrapper.Object);
            var result = subject.Get(new PathSettings { Target = PathTarget.Machine });

            Assert.That(result, Is.EqualTo("mach;ine"));
        }
    }
}