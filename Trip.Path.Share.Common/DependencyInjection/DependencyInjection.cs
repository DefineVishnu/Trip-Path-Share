using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Trip.Path.Share.Common.Repository;
using Trip.Path.Share.Common.UnitOfWork;

namespace Trip.Path.Share.Common.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCommonRepo(this IServiceCollection services)
        {
            services.TryAddTransient(typeof(IAsyncContextRepository<,,>), typeof(AsyncContextRepository<,,>));
            services.TryAddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            return services;
        }
    }
}
