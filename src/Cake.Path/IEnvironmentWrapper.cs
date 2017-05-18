namespace Cake.Path
{
    internal interface IEnvironmentWrapper
    {
        string GetEnvironmentVariable(string variable, PathTarget target, string @default = "");
        void SetEnvironmentVariable(string variable, string value, PathTarget target);
    }
}