using System;

namespace Cake.Path
{
    /// <summary>
    /// Extensions for the the PathTarget enum.
    /// </summary>
    public static class PathTargetExtensions
    {
        /// <summary>
        /// Converts to <c>PathTarget</c> to an <c>EnvironmentVariableTarget</c>.
        /// </summary>
        /// <example>
        /// <code>
        /// var environmentVariableTarget = PathTarget.Process.GetTarget();
        /// </code>
        /// </example>
        /// <returns>Returns an <c>EnvironmentVariableTarget</c>.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the <c>PathTarget</c> cannot be converted to an <c>EnvironmentVariableTarget</c>.</exception>
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