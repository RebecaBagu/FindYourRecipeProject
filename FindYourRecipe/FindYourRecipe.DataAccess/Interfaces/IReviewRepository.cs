using System;
using FindYourRecipe.DataAccess.Entities;

namespace FindYourRecipe.DataAccess.Interfaces
{
	public interface IReviewRepository
	{
		public Task<Review> GetByUserAsync(int userId);
		public Task<Review> GetByIdAsync(int id);
		public Task<List<Review>> GetAsync();
		public Task DeleteByIdAsync(int id);
		public Task<Review> CreateAsync(string text, int stars, int recipeId, int userId);
		public Task<Review> UpdateAsync(int id, string text, int stars, int recipeId, int userId);

	}
}

