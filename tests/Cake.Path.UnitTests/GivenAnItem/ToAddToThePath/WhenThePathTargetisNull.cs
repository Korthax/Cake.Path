using Cake.Core.Diagnostics;
using Moq;
using NUnit.Framework;

namespace Cake.Path.UnitTests.GivenAnItem.ToAddToThePath
{
    [TestFixture]
    public class WhenThePathTargetisNull
    {
        [Test]
        public void ThenTheEnvironmentVariableTargetIsDefaultedToUser()
        {
            var environmentWrapper = new Mock<IEnvironmentWrapper>();
            environmentWrapper.Setup(x => x.GetEnvironmentVariable("PATH", PathTarget.User, string.Empty)).Returns("test;test2");

            var subject = new PathWrapper(new NullLog(), environmentWrapper.Object);
            subject.Add("value", new PathSettings { Target = null });

            environmentWrapper.Verify(x => x.SetEnvironmentVariable("PATH", "test;test2;value", PathTarget.User), Times.Once);
        }
    }
}