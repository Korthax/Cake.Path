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
        /// <value>
        ///   Valid values; <c>User</c>, <c>Process</c>, or <c>Machine</c>. Defaults to <c>User</c>.
        /// </value>
        public PathTarget? Target { get; set; } = PathTarget.User;
    }
}