using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IOC
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUserServices, UserServices>();
        }
    }
}
