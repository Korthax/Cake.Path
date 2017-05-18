using Cake.Core.Diagnostics;
using Moq;
using NUnit.Framework;

namespace Cake.Path.UnitTests.GivenAnItem.ToRemoveFromThePath
{
    [TestFixture]
    public class WhenTheItemExistsInThePath
    {
        [Test]
        public void ThenTheItemIsRemovedFromThePath()
        {
            var environmentWrapper = new Mock<IEnvironmentWrapper>();
            environmentWrapper.Setup(x => x.GetEnvironmentVariable("PATH", PathTarget.Machine, string.Empty)).Returns("test;test2");

            var subject = new Path(new NullLog(), environmentWrapper.Object);
            subject.Remove("test", new PathSettings { Target = PathTarget.Machine });

            environmentWrapper.Verify(x => x.SetEnvironmentVariable("PATH", "test2", PathTarget.Machine), Times.Once);
        }
    }
}