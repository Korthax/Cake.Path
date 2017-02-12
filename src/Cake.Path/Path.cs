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

        public void Add(DirectoryPath value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value), "Value to add to path is null.");

            var parts = _environmentWrapper
                .GetEnvironmentVariable("PATH", string.Empty)
                .Split(';')
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList();

            if(parts.Contains(value.FullPath))
            {
                _log.Verbose($"PATH already contains '{value}'.");
                return;
            }

            parts.Add(value.FullPath);
            _environmentWrapper.SetEnvironmentVariable("PATH", string.Join(";", parts));
            _log.Verbose($"Added '{value}' to PATH.");
        }
    }
}