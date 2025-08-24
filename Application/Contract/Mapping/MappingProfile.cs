using AutoMapper;
using Backend.Domain.Contract.Model;
using System.Reflection;

namespace Backend.Application.Contract.Mapping
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Identity, Guid>().ConvertUsing(x => x.Id);
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in types)
            {

                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetInterface("IMapFrom`1")?.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}