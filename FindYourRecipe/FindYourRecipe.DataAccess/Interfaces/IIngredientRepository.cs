using System;
namespace FindYourRecipe.DataAccess.Interfaces
{
	public interface IIngredientRepository
	{
		Task<Ingredient> GetByIdAsync(int id);

        Task<List<Ingredient>> GetAsync();

        Task<Ingredient> CreateAsync(string name, string category);

		Task DeleteByIdAsync(int id);

        Task<Ingredient> UpdateAsync(int id,string name, string category);

        Task<bool> ExistsAsync(int id);
    }
}

