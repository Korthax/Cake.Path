using System;

namespace Cake.Path
{
    public class EnvironmentWrapper : IEnvironmentWrapper
    {
        public string GetEnvironmentVariable(string variable, string @default)
        {
            return Environment.GetEnvironmentVariable(variable) ?? @default;
        }

        public void SetEnvironmentVariable(string variable, string value)
        {
            Environment.SetEnvironmentVariable(variable, value);
        }
    }
}