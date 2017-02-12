using System;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Moq;
using Xunit;

namespace Cake.Path.UnitTests.GivenAnItem.ToRemoveFromThePath
{
    public class WhenTheSettingsAreNull
    {
        [Fact]
        public void ThenAnArgumentExceptionIsRaised()
        {
            var environmentWrapper = new Mock<IEnvironmentWrapper>();
            environmentWrapper.Setup(x => x.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.User, string.Empty)).Returns("test");

            var subject = new Path(new NullLog(), environmentWrapper.Object);

            Assert.Throws<ArgumentNullException>(() => { subject.Remove(new DirectoryPath("test"), null); });
        }
    }
}