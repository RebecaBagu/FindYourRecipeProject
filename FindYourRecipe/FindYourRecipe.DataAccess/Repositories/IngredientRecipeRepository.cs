using System;
using FindYourRecipe.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FindYourRecipe.DataAccess.Repositories
{
	public class IngredientRecipeRepository :IIngredientRecipeRepository
	{
        public DataContext Database { get; }
		public IngredientRecipeRepository(DataContext database)
		{
            Database = database;
		}

        public async Task<IngredientRecipe> CreateAsync(int ingredientId, int recipeId, string quantity)
        {
            IngredientRecipe ingredientRecipe = new IngredientRecipe()
            {
                IngredientId = ingredientId,
                RecipeId = recipeId,
                Quantity = quantity,
            };
            Database.Add(ingredientRecipe);
            await Database.SaveChangesAsync();
            return ingredientRecipe;
        }

        public async Task DeleteAsync(int id)
        {
            Database.Remove(await Database.IngredientsRecipes.FirstAsync(x => x.Id == id));
            await Database.SaveChangesAsync();
        }

        public Task<IngredientRecipe> GetByIdAsync(int id)
        {
            return Database.IngredientsRecipes.FirstAsync(x => x.Id == id);
        }

        public async Task<IngredientRecipe> UpdateAsync(int id, int ingredientId, int recipeId, string quantity)
        {
            IngredientRecipe toUpdate = await GetByIdAsync(id);
            toUpdate.IngredientId = ingredientId;
            toUpdate.RecipeId = recipeId;
            toUpdate.Quantity = quantity;
            await Database.SaveChangesAsync();
            return toUpdate;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            if (await Database.IngredientsRecipes.AnyAsync(p => p.Id == id))
            {
                return true;
            }
            else
                return false;
        }
    }
}

