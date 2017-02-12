using System;

namespace Cake.Path
{
    public static class PathTargetExtensions
    {
        public static EnvironmentVariableTarget GetTarget(this PathTarget self)
        {
            switch(self)
            {
                case PathTarget.User:
                    return EnvironmentVariableTarget.User;
                case PathTarget.Process:
                    return EnvironmentVariableTarget.Process;
                case PathTarget.Machine:
                    return EnvironmentVariableTarget.Machine;
                default:
                    throw new ArgumentOutOfRangeException(nameof(self), self, $"Unknown {typeof(PathTarget).Name} value '{self}'.");
            }
        }
    }
}