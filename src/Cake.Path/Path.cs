using System;
using System.Linq;
using Cake.Core.Diagnostics;
using Cake.Core.IO;

namespace Cake.Path
{
    public class Path
    {
        private readonly IEnvironmentWrapper _environmentWrapper;
        private readonly ICakeLog _log;

        public static Path Load(ICakeLog log)
        {
            return new Path(log, new EnvironmentWrapper());
        }

        internal Path(ICakeLog log, IEnvironmentWrapper environmentWrapper)
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

            var environmentVariableTarget = pathSettings
                .Target
                .GetValueOrDefault(PathTarget.User)
                .GetTarget();

            var parts = _environmentWrapper
                .GetEnvironmentVariable("PATH", environmentVariableTarget, string.Empty)
                .Split(';')
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList();

            if(parts.Contains(value.FullPath))
            {
                _log.Verbose($"PATH already contains '{value}'.");
                return;
            }

            parts.Add(value.FullPath);
            _environmentWrapper.SetEnvironmentVariable("PATH", string.Join(";", parts), environmentVariableTarget);
            _log.Verbose($"Added '{value}' to PATH.");
        }

        public void Remove(DirectoryPath value, PathSettings pathSettings)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value), "Value to add to path is null.");

            if (pathSettings == null)
                throw new ArgumentNullException(nameof(pathSettings), "Path settings is null.");

            var environmentVariableTarget = pathSettings
                .Target
                .GetValueOrDefault(PathTarget.User)
                .GetTarget();

            var parts = _environmentWrapper
                .GetEnvironmentVariable("PATH", environmentVariableTarget, string.Empty)
                .Split(';')
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList();

            if (!parts.Remove(value.FullPath))
            {
                _log.Verbose($"PATH does not contain '{value}'.");
                return;
            }

            _environmentWrapper.SetEnvironmentVariable("PATH", string.Join(";", parts), environmentVariableTarget);
            _log.Verbose($"Removed '{value}' from PATH.");
        }

        public void Reload()
        {
            var machinePath = _environmentWrapper.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Machine, string.Empty);
            var userPath = _environmentWrapper.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.User, string.Empty);
            _environmentWrapper.SetEnvironmentVariable("PATH", $"{machinePath};{userPath}", EnvironmentVariableTarget.Process);
            _log.Verbose("Reloaded PATH.");
        }
    }
}