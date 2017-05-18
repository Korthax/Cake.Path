using System;
using NUnit.Framework;

namespace Cake.Path.UnitTests.GivenAPathTarget
{
#if (NET45)
    [TestFixture]
    public class WhenConvertingToAnEnvironmentVariableTarget
    {
        [TestCase(PathTarget.User, EnvironmentVariableTarget.User)]
        [TestCase(PathTarget.Machine, EnvironmentVariableTarget.Machine)]
        [TestCase(PathTarget.Process, EnvironmentVariableTarget.Process)]
        public void ThenTheCorrectTypeIsMapped(PathTarget input, EnvironmentVariableTarget expected)
        {
            var result = input.GetTarget();
            Assert.That(result, Is.EqualTo(expected));
        }
    }
#endif
}