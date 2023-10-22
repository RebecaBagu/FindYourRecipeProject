using System;
using FindYourRecipe.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FindYourRecipe.DataAccess.Repositories
{
	public class CategoryRecipeRepository :ICategoryRecipeRepository
	{
        public DataContext Database { get; }
		public CategoryRecipeRepository(DataContext database)
		{
            Database = database;
		}

        public async Task<CategoryRecipe> CreateAsync(int categoryId, int recipeId)
        {
            CategoryRecipe categoryRecipe = new CategoryRecipe()
            {
                CategoryId = categoryId,
                RecipeId = recipeId,
            };
            Database.Add(categoryRecipe);
            await Database.SaveChangesAsync();
            return categoryRecipe;
        }

        public async Task DeleteAsync(int id)
        {
            Database.Remove(await Database.CategoryRecipes.FirstAsync(x => x.Id == id));
            await Database.SaveChangesAsync();
        }

        public  Task<CategoryRecipe> GetByIdAsync(int id)
        {
            return  Database.CategoryRecipes.FirstAsync(x => x.Id == id);
            
        }

        public async Task<CategoryRecipe> UpdateAsync(int id, int categoryId, int recipeId)
        {
            CategoryRecipe toUpdate = await GetByIdAsync(id);
            toUpdate.CategoryId = categoryId;
            toUpdate.RecipeId = recipeId;
            await Database.SaveChangesAsync();
            return toUpdate;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            if (await Database.CategoryRecipes.AnyAsync(p => p.Id == id))
            {
                return true;
            }
            else
                return false;
        }

        public Task<List<CategoryRecipe>> GetAsync()
        {
            return Database.CategoryRecipes.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task DeleteByRecipeIdAsync(int recipeId)
        {
            var categories = await (from category in Database.CategoryRecipes
                                where (category.RecipeId == recipeId)
                                select category).ToListAsync();
            Database.RemoveRange(categories);
            await Database.SaveChangesAsync();
        }
    }
}

