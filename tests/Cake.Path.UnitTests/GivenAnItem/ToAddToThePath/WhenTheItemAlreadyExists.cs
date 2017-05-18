using Cake.Core.Diagnostics;
using Moq;
using NUnit.Framework;

namespace Cake.Path.UnitTests.GivenAnItem.ToAddToThePath
{
    [TestFixture]
    public class WhenTheItemAlreadyExists
    {
        [Test]
        public void ThenThePathIsNotModified()
        {
            var environmentWrapper = new Mock<IEnvironmentWrapper>();
            environmentWrapper.Setup(x => x.GetEnvironmentVariable("PATH", PathTarget.Machine, string.Empty)).Returns("test;test2");

            var subject = new Path(new NullLog(), environmentWrapper.Object);
            subject.Add("test", new PathSettings { Target = PathTarget.Machine });

            environmentWrapper.Verify(x => x.SetEnvironmentVariable(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<PathTarget>()), Times.Never);
        }
    }
}