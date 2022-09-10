using Microsoft.Extensions.DependencyInjection;
using Trip.Path.Share.Data.Persistance;

namespace Trip.Path.Share.Data.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUserSharePersistance(this IServiceCollection services)
        {
            services.AddDbContext<UserDbContext>();
            return services;
        }
    }
}