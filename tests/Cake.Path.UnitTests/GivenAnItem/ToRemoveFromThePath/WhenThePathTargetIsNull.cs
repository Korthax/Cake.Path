using Cake.Core.Diagnostics;
using Moq;
using NUnit.Framework;

namespace Cake.Path.UnitTests.GivenAnItem.ToRemoveFromThePath
{
    [TestFixture]
    public class WhenThePathTargetIsNull
    {
        [Test]
        public void ThenTheEnvironmentVariableTargetIsDefaultedToUser()
        {
            var environmentWrapper = new Mock<IEnvironmentWrapper>();
            environmentWrapper.Setup(x => x.GetEnvironmentVariable("PATH", PathTarget.User, string.Empty)).Returns("test;test2");

            var subject = new PathWrapper(new NullLog(), environmentWrapper.Object);
            subject.Remove("test", new PathSettings { Target = null });

            environmentWrapper.Verify(x => x.SetEnvironmentVariable("PATH", "test2", PathTarget.User), Times.Once);
        }
    }
}