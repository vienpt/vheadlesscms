using Microsoft.Extensions.DependencyInjection;
using Recipe.API.Application.Interfaces;
using Recipe.API.Infrastructure.Repositories;

namespace Recipe.API.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IRecipeRepository, RecipeRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}