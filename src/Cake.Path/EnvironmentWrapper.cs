using System;

namespace Cake.Path
{
    /// <summary>
    /// Wrapper for accessing the environment.
    /// </summary>
    public class EnvironmentWrapper : IEnvironmentWrapper
    {
        /// <summary>
        /// Gets an environment variable.
        /// </summary>
        /// <example>
        /// <code>
        /// string currentUser = new EnvironmentWrapper().GetEnvironmentVariable("CurrentUser", EnvironmentVariableTarget.Process, "Korthax");
        /// </code>
        /// </example>
        /// <param name="variable">The name of the environment variable to get.</param>
        /// <param name="target">The location of the environment variable.</param>
        /// <param name="default">The value to return when the variable is not found.</param>
        /// <returns>Returns a <c>string</c> containing the environment variable</returns>
        public string GetEnvironmentVariable(string variable, EnvironmentVariableTarget target, string @default = "")
        {
            return Environment.GetEnvironmentVariable(variable, target) ?? @default;
        }

        /// <summary>
        /// Sets an environment variable.
        /// </summary>
        /// <example>
        /// <code>
        /// new EnvironmentWrapper().SetEnvironmentVariable("Path", "D:\code", EnvironmentVariableTarget.Process);
        /// </code>
        /// </example>
        /// <param name="variable">The name of the environment variable to set.</param>
        /// <param name="value">The value of the environment variable.</param>
        /// <param name="target">The location of the environment variable.</param>
        public void SetEnvironmentVariable(string variable, string value, EnvironmentVariableTarget target)
        {
            Environment.SetEnvironmentVariable(variable, value, target);
        }
    }
}