using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Moq;
using NUnit.Framework;

namespace Cake.Path.UnitTests.GivenAnItem.ToAddToThePath
{
    [TestFixture]
    public class WhenThePathIsNull
    {
        [Test]
        public void ThenANewPathIsAddedWithTheValue()
        {
            var environmentWrapper = new Mock<IEnvironmentWrapper>();
            environmentWrapper.Setup(x => x.GetEnvironmentVariable("PATH", PathTarget.User, string.Empty)).Returns(string.Empty);

            var subject = new PathWrapper(new NullLog(), environmentWrapper.Object);
            subject.Add(new DirectoryPath("test"), new PathSettings { Target = PathTarget.User });
 
            environmentWrapper.Verify(x => x.SetEnvironmentVariable("PATH", "test", PathTarget.User), Times.Once);
        }
    }
}