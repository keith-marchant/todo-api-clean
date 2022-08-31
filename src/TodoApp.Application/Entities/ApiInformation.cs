using System.Reflection;

namespace TodoApp.Application.Entities
{
    /// <summary>
    /// Object providing information about an API's version.
    /// </summary>
    public class ApiInformation
    {
        /// <summary>
        /// Create a new <see cref="ApiInformation"/>.
        /// </summary>
        /// <param name="assembly">The assembly to read.</param>
        /// <exception cref="ArgumentNullException">Thrown if assembly is null.</exception>
        public ApiInformation(Assembly assembly)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly));
            }

            Name = assembly.GetName().Name;
            Version = assembly.GetName().Version?.ToString();
        }

        /// <summary>
        /// Gets the API name.
        /// </summary>
        public string? Name { get; }
        /// <summary>
        /// Gets the API version.
        /// </summary>
        public string? Version { get; }
    }
}
