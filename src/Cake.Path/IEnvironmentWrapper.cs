namespace Cake.Path
{
    public interface IEnvironmentWrapper
    {
        string GetEnvironmentVariable(string variable, string @default);
        void SetEnvironmentVariable(string variable, string value);
    }
}