using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Recipe.API.Application.Interfaces;
using Recipe.API.Model;

namespace Recipe.API.Infrastructure.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        // private IConfiguration Configuration { get; }

        private readonly string _connectionString;

        public RecipeRepository(IConfiguration configuration)
        {
            // Configuration = configuration;
            _connectionString = configuration.GetConnectionString("RecipeContext");
        }
        
        public Task<RecipeItem> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<RecipeItem>> GetAllAsync()
        {
            using var connection = DbConnection.GetDbConnection(_connectionString);
            const string sql = "select * from recipes";
            var items = await connection.QueryAsync<RecipeItem>(sql);
            return items.ToList();
        }

        public async Task<int> AddAsync(RecipeItem entity)
        {
            // var newEntity = entity with
            // {
            //     Title = "Shaved Brussels Sprout and Snap Peas Salad",
            //     Description = "This salad is not a star on it's own but is light and crisp and is a nice compliment to a rich dish. Perfect for when you're tired of the same old salad",
            //     Content = "Sugar snap peas, trimmed and diagonally cut, 1lb brussels sprouts, shaved, Goat or feta cheese crumbles",
            //     Meal = "Lunch",
            //     Time = 5,
            //     Rating = 2,
            //     Order = 6
            // };
            // entity.CreatedAt = DateTimeOffset.Now;
            // var sql = "Insert into recipes" +
            //     "(Title, Description, Meal, Img, Time, Rating, Order, CreatedAt, UpdatedAt, TagId, AuthorId)" +
            //     "VALUES (@Title, ";
            using var connection = DbConnection.GetDbConnection(_connectionString);
            connection.Open();
            var result = await connection.ExecuteAsync("", entity);
            return result;
        }

        public Task<int> UpdateAsync(RecipeItem entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}