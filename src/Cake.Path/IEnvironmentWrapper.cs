using System;

namespace Cake.Path
{
    public interface IEnvironmentWrapper
    {
        string GetEnvironmentVariable(string variable, EnvironmentVariableTarget target, string @default = "");
        void SetEnvironmentVariable(string variable, string value, EnvironmentVariableTarget target);
    }
}