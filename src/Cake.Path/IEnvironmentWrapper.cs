using System;

namespace Cake.Path
{
    /// <summary>
    /// Wrapper for accessing the environment.
    /// </summary>
    public interface IEnvironmentWrapper
    {
        /// <summary>
        /// Gets an environment variable.
        /// </summary>
        /// <param name="variable">The name of the environment variable to get.</param>
        /// <param name="target">The location of the environment variable.</param>
        /// <param name="default">The value to return when the variable is not found.</param>
        /// <returns>Returns a <c>string</c> containing the environment variable</returns>
        string GetEnvironmentVariable(string variable, EnvironmentVariableTarget target, string @default = "");

        /// <summary>
        /// Sets an environment variable.
        /// </summary>
        /// <param name="variable">The name of the environment variable to set.</param>
        /// <param name="value">The value of the environment variable.</param>
        /// <param name="target">The location of the environment variable.</param>
        void SetEnvironmentVariable(string variable, string value, EnvironmentVariableTarget target);
    }
}