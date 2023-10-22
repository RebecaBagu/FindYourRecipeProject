using System;
namespace FindYourRecipe.DataAccess.Interfaces
{
	public interface IIngredientRepository
	{
		Task<Ingredient> GetByIdAsync(int id);

        Task<List<Ingredient>> GetAsync(int skip, int take);

        Task<Ingredient> CreateAsync(string name, string category);

		Task DeleteByIdAsync(int id);

        Task<Ingredient> UpdateAsync(int id,string name, string category);

        Task<bool> ExistsAsync(int id);

        Task<int> GetCountAsync();

        
    }
}

