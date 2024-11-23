using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DataAccess.Mappings;
public static class DependencyInjection
{
    public static void AddAutoMapperConfig(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}
