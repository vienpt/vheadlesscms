using Recipe.API.Application.Interfaces;

namespace Recipe.API.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IRecipeRepository recipeRepository)
        {
            Recipes = recipeRepository;
        }
        public IRecipeRepository Recipes { get; }
    }
}