using System;
namespace FindYourRecipe.DataAccess.Interfaces
{
	public interface ICategoryRepository
	{
		Task<Category> GetByIdAsync(int id);

		Task<Category> CreateAsync(string name);

		Task DeleteAsync(int id);

        Task< bool> ExistsAsync(int id);
    }

}

