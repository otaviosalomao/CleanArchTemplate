using Microsoft.Extensions.DependencyInjection;

namespace Presentation
{
    public static class DepedencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {         
            return services;
        }
    }
}
