using Cake.Core.Diagnostics;
using Moq;
using NUnit.Framework;

namespace Cake.Path.UnitTests.GivenAnItem.ToRemoveFromThePath
{
    [TestFixture]
    public class WhenTheItemDoesNotExists
    {
        [Test]
        public void ThenThePathIsNotModified()
        {
            var environmentWrapper = new Mock<IEnvironmentWrapper>();
            environmentWrapper.Setup(x => x.GetEnvironmentVariable("PATH", PathTarget.User, string.Empty)).Returns("test;test2");

            var subject = new PathWrapper(new NullLog(), environmentWrapper.Object);
            subject.Remove("test3", new PathSettings { Target = PathTarget.User });

            environmentWrapper.Verify(x => x.SetEnvironmentVariable(It.IsAny<string>(), It.IsAny<string>(), PathTarget.User), Times.Never);
        }
    }
}