using System;
using FindYourRecipe.DataAccess.Entities;
using FindYourRecipe.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FindYourRecipe.DataAccess.Repositories
{
	public class ReviewRepository:IReviewRepository
	{
        public DataContext Database { get; }

        public ReviewRepository(DataContext database)
        {
            Database = database;
        }

        public async Task<Review> CreateAsync(string text, int stars, int recipeId, int userId)
        {
            var review = new Review()
            {
                Text = text,
                Stars = stars,
                RecipeId = recipeId,
                UserId = userId
            };
            Database.Add(review);
            await Database.SaveChangesAsync();
            return review;
        }

        public async Task DeleteByIdAsync(int id)
        {
            Database.Remove(await Database.Reviews.FirstAsync(x => x.Id == id));
            await Database.SaveChangesAsync();
        }

        public Task<List<Review>> GetAsync()
        {
            return Database.Reviews.OrderBy(x => x.Id).ToListAsync();
        }

        public Task<Review> GetByIdAsync(int id)
        {
            return Database.Reviews.FirstAsync(x => x.Id == id);
        }

        public Task<Review> GetByUserAsync(int userId)
        {
            return Database.Reviews.FirstAsync(x => x.UserId == userId);
        }

        public async Task<Review> UpdateAsync(int id, string text, int stars, int recipeId, int userId)
        {
            var reviewToUpdate = await GetByIdAsync(id);
            reviewToUpdate.Text = text;
            reviewToUpdate.Stars = stars;
            reviewToUpdate.RecipeId = recipeId;
            reviewToUpdate.UserId = userId;
            await Database.SaveChangesAsync();
            return reviewToUpdate;
        }
    }
}

