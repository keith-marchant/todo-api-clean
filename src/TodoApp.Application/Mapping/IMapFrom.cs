using AutoMapper;

namespace TodoApp.Application.Mapping
{
    /// <summary>
    /// Extension for AutoMapper to automatically generate mapping profiles.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMapFrom<T>
    {
        /// <summary>
        /// The mapping to add to the existing profile.
        /// </summary>
        /// <param name="profile">The profile to add a mapping to.</param>
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
