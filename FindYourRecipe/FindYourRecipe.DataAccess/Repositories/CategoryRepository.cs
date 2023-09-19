using System;
using FindYourRecipe.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FindYourRecipe.DataAccess.Repositories
{
	public class CategoryRepository :ICategoryRepository
	{
		public DataContext Database { get; }
		public CategoryRepository(DataContext database)
		{
			Database = database;
		}

        public Task<Category> GetByIdAsync(int id)
        {
            return Database.Category.FirstAsync(x => x.Id == id);
        }

        public async Task<Category> CreateAsync(string name)
        {
            Category category = new Category()
            {
                Name = name,
            };
            Database.Add(category);
            await Database.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateAsync(int id, string name)
        {
            Category toUpdate = await GetByIdAsync(id);
            toUpdate.Name = name;
            await Database.SaveChangesAsync();
            return toUpdate;
        }

        public async Task DeleteAsync(int id)
        {
             Database.Remove(await Database.Category.FirstAsync(x => x.Id == id));
             await Database.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            if (await Database.Category.AnyAsync(p => p.Id == id))
            {
                return true;
            }
            else
                return false;
        }
    }
}

