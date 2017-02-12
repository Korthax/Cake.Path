using System;
using Xunit;

namespace Cake.Path.UnitTests.GivenAPathTarget
{
    public class WhenConvertingToAnEnvironmentVariableTarget
    {
        [Theory]
        [InlineData(PathTarget.User, EnvironmentVariableTarget.User)]
        [InlineData(PathTarget.Machine, EnvironmentVariableTarget.Machine)]
        [InlineData(PathTarget.Process, EnvironmentVariableTarget.Process)]
        public void ThenTheCorrectTypeIsMapped(PathTarget input, EnvironmentVariableTarget expected)
        {
            var result = input.GetTarget();
            Assert.Equal(result, expected);
        }
    }
}