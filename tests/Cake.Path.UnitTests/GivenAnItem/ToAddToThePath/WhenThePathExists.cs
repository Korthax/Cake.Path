using System;
using Cake.Core.Diagnostics;
using Moq;
using Xunit;

namespace Cake.Path.UnitTests.GivenAnItem.ToAddToThePath
{
    public class WhenThePathExists
    {
        [Fact]
        public void ThenTheItemIsAddedToTheEndOfThePath()
        {
            var environmentWrapper = new Mock<IEnvironmentWrapper>();
            environmentWrapper.Setup(x => x.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Process, string.Empty)).Returns("test;test2");

            var subject = new Path(new NullLog(), environmentWrapper.Object);
            subject.Add("value", new PathSettings { Target = PathTarget.Process });

            environmentWrapper.Verify(x => x.SetEnvironmentVariable("PATH", "test;test2;value", EnvironmentVariableTarget.Process), Times.Once);
        }
    }
}