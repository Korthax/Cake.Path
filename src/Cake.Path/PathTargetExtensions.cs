#if (NET45)
using System;
#endif

namespace Cake.Path
{
    internal static class PathTargetExtensions
    {
#if (NET45)
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
#endif
    }
}