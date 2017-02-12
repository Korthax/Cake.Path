using System;
using Cake.Core.Diagnostics;
using Moq;
using Xunit;

namespace Cake.Path.UnitTests.GivenAnItem.ToRemoveFromThePath
{
    public class WhenTheValueIsNull
    {
        [Fact]
        public void ThenAnArgumentExceptionIsRaised()
        {
            var environmentWrapper = new Mock<IEnvironmentWrapper>();
            environmentWrapper.Setup(x => x.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.User, string.Empty)).Returns("test");

            var subject = new Path(new NullLog(), environmentWrapper.Object);

            Assert.Throws<ArgumentNullException>(() => { subject.Remove(null, new PathSettings { Target = PathTarget.User }); });
        }
    }
}