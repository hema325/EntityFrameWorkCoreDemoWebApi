using AutoMapper;
using System.Reflection;

namespace WebApiEntityFramework.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var mapFromType = typeof(IMapFrom<>);
            var mapToType = typeof(IMapTo<>);
            var mappingMethodName = nameof(IMapFrom<object>.Mapping);

            Func<Type, bool> mapFromFilter = type => type.IsGenericType && type.GetGenericTypeDefinition() == mapFromType.GetGenericTypeDefinition();
            Func<Type, bool> mapToFilter = type => type.IsGenericType && type.GetGenericTypeDefinition() == mapToType.GetGenericTypeDefinition();

            var types = assembly.GetTypes().Where(type => type.GetInterfaces().Any(i => mapFromFilter(i) || mapToFilter(i)));

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod(mappingMethodName);

                if (methodInfo != null)
                    methodInfo.Invoke(instance, new object[] { this });
                else
                {
                    var interfaces = type.GetInterfaces().Where(i => mapFromFilter(i) || mapToFilter(i));

                    foreach (var interfaceType in interfaces)
                    {
                        var interfaceMethodInfo = interfaceType.GetMethod(mappingMethodName);

                        interfaceMethodInfo?.Invoke(instance, new object[] { this });
                    }
                }
            }
        }
    }
}
