using System;
using System.Linq;
using Cake.Core.Diagnostics;
using Cake.Core.IO;

namespace Cake.Path
{
    /// <summary>
    /// Class that represents the Windows PATH environment variable.
    /// </summary>
    internal class Path
    {
        private readonly IEnvironmentWrapper _environmentWrapper;
        private readonly ICakeLog _log;

        /// <summary>
        /// Loads a path.
        /// </summary>
        /// <param name="log">The Cake logger.</param>
        /// <returns>Returns a <c>Path</c>.</returns>
        public static Path Load(ICakeLog log)
        {
            return new Path(log, new EnvironmentWrapper());
        }

        internal Path(ICakeLog log, IEnvironmentWrapper environmentWrapper)
        {
            _log = log;
            _environmentWrapper = environmentWrapper;
        }

        /// <summary>
        /// Adds a value to the path.
        /// </summary>
        /// <param name="value">Item to be added to the path.</param>
        /// <param name="pathSettings">Path settings used for the value.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when either the <c>DirectoryPath</c> or <c>PathSettings</c> is null.</exception>
        public void Add(DirectoryPath value, PathSettings pathSettings)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value), "Value to add to path is null.");

            if (pathSettings == null)
                throw new ArgumentNullException(nameof(pathSettings), "Path settings is null.");

            var pathTarget = pathSettings
                .Target
                .GetValueOrDefault(PathTarget.User);

            var parts = _environmentWrapper
                .GetEnvironmentVariable("PATH", pathTarget, string.Empty)
                .Split(';')
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList();

            if(parts.Contains(value.FullPath))
            {
                _log.Verbose($"PATH already contains '{value}'.");
                return;
            }

            parts.Add(value.FullPath);
            _environmentWrapper.SetEnvironmentVariable("PATH", string.Join(";", parts), pathTarget);
            _log.Verbose($"Added '{value}' to PATH.");
        }

        /// <summary>
        /// Removes a value from the PATH. If the item is not found in the path then nothing will happen.
        /// </summary>
        /// <param name="value">Item to be removed to the path.</param>
        /// <param name="pathSettings">Path settings used for the value.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when either the <c>DirectoryPath</c> or <c>PathSettings</c> is null.</exception>
        public void Remove(DirectoryPath value, PathSettings pathSettings)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value), "Value to add to path is null.");

            if (pathSettings == null)
                throw new ArgumentNullException(nameof(pathSettings), "Path settings is null.");

            var pathTarget = pathSettings
                .Target
                .GetValueOrDefault(PathTarget.User);

            var parts = _environmentWrapper
                .GetEnvironmentVariable("PATH", pathTarget, string.Empty)
                .Split(';')
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList();

            if (!parts.Remove(value.FullPath))
            {
                _log.Verbose($"PATH does not contain '{value}'.");
                return;
            }

            _environmentWrapper.SetEnvironmentVariable("PATH", string.Join(";", parts), pathTarget);
            _log.Verbose($"Removed '{value}' from PATH.");
        }

        /// <summary>
        /// Reloads the in process PATH environment variable.
        /// </summary>
        public void Reload()
        {
#if (NETSTANDARD1_6)
            var userPath = _environmentWrapper.GetEnvironmentVariable("PATH", PathTarget.User, string.Empty);
            _environmentWrapper.SetEnvironmentVariable("PATH", $"{userPath}", PathTarget.Process);
#else
            var machinePath = _environmentWrapper.GetEnvironmentVariable("PATH", PathTarget.Machine, string.Empty);
            var userPath = _environmentWrapper.GetEnvironmentVariable("PATH", PathTarget.User, string.Empty);
            _environmentWrapper.SetEnvironmentVariable("PATH", $"{machinePath};{userPath}", PathTarget.Process);
#endif
            _log.Verbose("Reloaded PATH.");
        }
    }
}