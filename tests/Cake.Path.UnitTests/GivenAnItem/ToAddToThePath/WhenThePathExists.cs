using Cake.Core.Diagnostics;
using Moq;
using NUnit.Framework;

namespace Cake.Path.UnitTests.GivenAnItem.ToAddToThePath
{
    [TestFixture]
    public class WhenThePathExists
    {
        [Test]
        public void ThenTheItemIsAddedToTheEndOfThePath()
        {
            var environmentWrapper = new Mock<IEnvironmentWrapper>();
            environmentWrapper.Setup(x => x.GetEnvironmentVariable("PATH", PathTarget.Process, string.Empty)).Returns("test;test2");

            var subject = new PathWrapper(new NullLog(), environmentWrapper.Object);
            subject.Add("value", new PathSettings { Target = PathTarget.Process });

            environmentWrapper.Verify(x => x.SetEnvironmentVariable("PATH", "test;test2;value", PathTarget.Process), Times.Once);
        }
    }
}