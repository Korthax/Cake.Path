using System;
using System.Linq;
using Cake.Core.Diagnostics;
using Cake.Core.IO;

namespace Cake.Path
{
    internal class PathWrapper
    {
        private readonly IEnvironmentWrapper _environmentWrapper;
        private readonly ICakeLog _log;

        public static PathWrapper Load(ICakeLog log)
        {
            return new PathWrapper(log, new EnvironmentWrapper());
        }

        internal PathWrapper(ICakeLog log, IEnvironmentWrapper environmentWrapper)
        {
            _log = log;
            _environmentWrapper = environmentWrapper;
        }

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

        public string Get(PathSettings pathSettings)
        {
            var pathTarget = pathSettings
                .Target
                .GetValueOrDefault(PathTarget.User);

            return _environmentWrapper.GetEnvironmentVariable("PATH", pathTarget, string.Empty);
        }
    }
}