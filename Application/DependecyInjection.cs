//using Application.Topics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplictionServices(
                this IServiceCollection services,
                IConfiguration configuration
            )
        {
            //services.AddScoped<ITopicService, TopicService>();

            return services;
        }
    }
}