using VectorApi.Application;
using VectorPermutationTests;

namespace VectorApi.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddVectorService(this IServiceCollection services)
        {
            services.AddScoped<IVectorService, VectorService>();

            return services;
        }
    }
}
