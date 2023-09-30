using System;
namespace FindYourRecipe.DataAccess.Interfaces
{
	public interface ICategoryRepository
	{
		Task<Category> GetByIdAsync(int id);

        Task<List<Category>> GetAsync();

		Task<Category> CreateAsync(string name);

        Task<Category> UpdateAsync(int id, string name);

        Task DeleteAsync(int id);

        Task< bool> ExistsAsync(int id);
    }

}

