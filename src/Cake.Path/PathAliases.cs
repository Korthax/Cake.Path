using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;

namespace Cake.Path
{
    /// <summary>
    /// Contains functionality for manipulating the path.
    /// </summary>
    [CakeAliasCategory("Path")]
    public static class PathAliases
    {
        /// <summary>
        /// Adds a value to the path.
        /// </summary>
        /// <example>
        /// <code>
        /// Task("AddToPath")
        ///   .Does(() => 
        ///   {
        ///      AddToPath("C:\\Python27\\");
        ///   });
        /// </code>
        /// </example>
        /// <param name="context">The context.</param>
        /// <param name="value">Item to add.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when the <c>ICakeContext</c> is null.</exception>
        [CakeMethodAlias]
        public static void AddToPath(this ICakeContext context, DirectoryPath value)
        {
            AddToPath(context, value, new PathSettings());
        }

        /// <summary>
        /// Adds a value to the path.
        /// </summary>
        /// <example>
        /// <code>
        /// Task("AddToPath")
        ///   .Does(() => 
        ///   {
        ///      var settings = new PathSettings {
        ///         Target = PathTarget.User // Target is only available in net45
        ///      }
        ///
        ///      AddToPath("C:\\Python27\\", settings);
        ///   });
        /// </code>
        /// </example>
        /// <param name="context">The context.</param>
        /// <param name="value">Item to add.</param>
        /// <param name="pathSettings">Settings for the PATH.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when the <c>ICakeContext</c> is null.</exception>
        [CakeMethodAlias]
        public static void AddToPath(this ICakeContext context, DirectoryPath value, PathSettings pathSettings)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            PathWrapper.Load(context.Log)
                .Add(value, pathSettings);
        }

        /// <summary>
        /// Removes a value from the path.
        /// </summary>
        /// <example>
        /// <code>
        /// Task("RemoveFromPath")
        ///   .Does(() => 
        ///   {
        ///      RemoveFromPath("C:\\Python27\\");
        ///   });
        /// </code>
        /// </example>
        /// <param name="context">The context.</param>
        /// <param name="value">Item to remove.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when the <c>ICakeContext</c> is null.</exception>
        [CakeMethodAlias]
        public static void RemoveFromPath(this ICakeContext context, DirectoryPath value)
        {
            RemoveFromPath(context, value, new PathSettings());
        }

        /// <summary>
        /// Removes a value from the path.
        /// </summary>
        /// <example>
        /// <code>
        /// Task("RemoveFromPath")
        ///   .Does(() => 
        ///   {
        ///      var settings = new PathSettings {
        ///         Target = PathTarget.User // Target is only available in net45
        ///      }
        ///
        ///      RemoveFromPath("C:\\Python27\\", settings);
        ///   });
        /// </code>
        /// </example>
        /// <param name="context">The context.</param>
        /// <param name="value">Item to remove.</param>
        /// <param name="pathSettings">Settings for the PATH.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when the <c>ICakeContext</c> is null.</exception>
        [CakeMethodAlias]
        public static void RemoveFromPath(this ICakeContext context, DirectoryPath value, PathSettings pathSettings)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            PathWrapper.Load(context.Log)
                .Remove(value, pathSettings);
        }

        /// <summary>
        /// Reloads an in process path.
        /// </summary>
        /// <example>
        /// <code>
        /// Task("ReloadPath")
        ///   .Does(() => 
        ///   {
        ///      ReloadPath();
        ///   });
        /// </code>
        /// </example>
        /// <param name="context">The context.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when the <c>ICakeContext</c> is null.</exception>
        [CakeMethodAlias]
        public static void ReloadPath(this ICakeContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            PathWrapper.Load(context.Log)
                .Reload();
        }

        /// <summary>
        /// Gets the environment's path.
        /// </summary>
        /// <example>
        /// <code>
        /// Task("GetEnvironmentPath")
        ///   .Does(() => 
        ///   {
        ///      string path = GetEnvironmentPath();
        ///   });
        /// </code>
        /// </example>
        /// <param name="context">The context.</param>
        /// <returns>Returns a <c>string</c> containing the path</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the <c>ICakeContext</c> is null.</exception>
        [CakeMethodAlias]
        public static string GetEnvironmentPath(this ICakeContext context)
        {
            return GetEnvironmentPath(context, new PathSettings());
        }


        /// <summary>
        /// Gets the environment's path.
        /// </summary>
        /// <example>
        /// <code>
        /// Task("GetEnvironmentPath")
        ///   .Does(() => 
        ///   {
        ///      var settings = new PathSettings {
        ///         Target = PathTarget.User // Target is only available in net45
        ///      }
        /// 
        ///      string path = GetEnvironmentPath(settings);
        ///   });
        /// </code>
        /// </example>
        /// <param name="context">The context.</param>
        /// <param name="pathSettings">Settings for the PATH.</param>
        /// <returns>Returns a <c>string</c> containing the path</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the <c>ICakeContext</c> is null.</exception>
        [CakeMethodAlias]
        public static string GetEnvironmentPath(this ICakeContext context, PathSettings pathSettings)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            return PathWrapper.Load(context.Log)
                .Get(pathSettings);
        }
    }
}
