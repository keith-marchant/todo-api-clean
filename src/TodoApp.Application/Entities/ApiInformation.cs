using System.Reflection;

namespace TodoApp.Application.Entities
{
    public class ApiInformation
    {
        public ApiInformation(Assembly assembly)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly));
            }

            Name = assembly.GetName().Name;
            Version = assembly.GetName().Version?.ToString();
        }

        public string? Name { get; set; }
        public string? Version { get; set; }
    }
}
