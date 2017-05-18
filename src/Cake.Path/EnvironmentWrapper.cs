using System;

namespace Cake.Path
{
    internal class EnvironmentWrapper : IEnvironmentWrapper
    {
        public string GetEnvironmentVariable(string variable, PathTarget target, string @default = "")
        {
#if (NETSTANDARD1_6)
            return Environment.GetEnvironmentVariable(variable) ?? @default;
#else
            return Environment.GetEnvironmentVariable(variable, target.GetTarget()) ?? @default;
#endif
        }

        public void SetEnvironmentVariable(string variable, string value, PathTarget target)
        {
#if (NETSTANDARD1_6)
            Environment.SetEnvironmentVariable(variable, value);
#else
            Environment.SetEnvironmentVariable(variable, value, target.GetTarget());
#endif
        }
    }
}