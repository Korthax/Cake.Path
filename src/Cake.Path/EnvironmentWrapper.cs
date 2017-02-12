using System;

namespace Cake.Path
{
    public class EnvironmentWrapper : IEnvironmentWrapper
    {
        public string GetEnvironmentVariable(string variable, EnvironmentVariableTarget target, string @default = "")
        {
            return Environment.GetEnvironmentVariable(variable, target) ?? @default;
        }

        public void SetEnvironmentVariable(string variable, string value, EnvironmentVariableTarget target)
        {
            Environment.SetEnvironmentVariable(variable, value, target);
        }
    }
}