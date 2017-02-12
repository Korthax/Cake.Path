namespace Cake.Path
{
    /// <summary>
    /// Location of the PATH environment variable
    /// </summary>
    public enum PathTarget
    {
        /// <summary>
        /// The path is stored or retrieved from the HKEY_CURRENT_USER\Environment key in the Windows operating system registry.
        /// </summary>
        User,
        /// <summary>
        /// The path is stored or retrieved from the environment block associated with the current process.
        /// </summary>
        Process,
        /// <summary>
        /// The path is stored or retrieved from the HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\Session Manager\Environment key in the Windows operating system registry.
        /// </summary>
        Machine
    }
}