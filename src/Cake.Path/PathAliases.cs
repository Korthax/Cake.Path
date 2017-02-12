using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;

namespace Cake.Path
{
    /// <summary>
    /// Contains functionality for manipulating the path
    /// </summary>
    [CakeAliasCategory("Path")]
    public static class PathAliases
    {
        /// <summary>
        /// Adds a value to the path
        /// </summary>
        /// <example>
        /// <code>
        /// Task("AddToPath")
        ///   .Does(() => 
        ///   {
        ///      AddToPath("C:\Python27");
        ///   });
        /// </code>
        /// </example>
        /// <param name="context">The context.</param>
        /// <param name="value">Item to add</param>
        [CakeMethodAlias]
        public static void AddToPath(this ICakeContext context, DirectoryPath value)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            Path.Load(context.Log)
                .Add(value);
        }
    }
}
