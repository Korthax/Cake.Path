namespace Cake.Path
{
    /// <summary>
    /// Settings for the PATH operations.
    /// </summary>
    public class PathSettings
    {
        /// <summary>
        /// Specifies the location where path is stored or retrieved in a set or get operation.
        /// </summary>
        public PathTarget? Target { get; set; } = PathTarget.User;
    }
}