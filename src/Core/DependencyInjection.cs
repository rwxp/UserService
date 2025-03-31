using Microsoft.Extensions.DependencyInjection;
using Core.Ports.In;
using Core.Services;

namespace Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
            => services
                .AddScoped<IUserService, UserService>()
                .AddSingleton<JwtService>();
    }
}