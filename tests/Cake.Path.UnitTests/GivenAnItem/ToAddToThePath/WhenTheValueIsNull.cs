using System;
using Cake.Core.Diagnostics;
using Moq;
using NUnit.Framework;

namespace Cake.Path.UnitTests.GivenAnItem.ToAddToThePath
{
    [TestFixture]
    public class WhenTheValueIsNull
    {
        [Test]
        public void ThenAnArgumentExceptionIsRaised()
        {
            var environmentWrapper = new Mock<IEnvironmentWrapper>();
            environmentWrapper.Setup(x => x.GetEnvironmentVariable("PATH", PathTarget.User, string.Empty)).Returns("test");

            var subject = new PathWrapper(new NullLog(), environmentWrapper.Object);

            Assert.Throws<ArgumentNullException>(() => { subject.Add(null, new PathSettings { Target = PathTarget.User }); });
        }
    }
}