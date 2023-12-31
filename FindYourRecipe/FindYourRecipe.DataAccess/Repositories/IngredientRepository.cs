﻿using System;
using FindYourRecipe.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FindYourRecipe.DataAccess.Repositories
{
	public class IngredientRepository :IIngredientRepository
	{
        public DataContext Database { get; }
		public IngredientRepository(DataContext database)
		{
            Database = database;
		}

        public async Task<Ingredient> CreateAsync(string name, string category)
        {
            Ingredient ingredient = new Ingredient()
            {
                Name=name,
                Category=category,
            };
            Database.Add(ingredient);
            await Database.SaveChangesAsync();
            return ingredient;
        }

        public async Task DeleteByIdAsync(int id)
        {
            Database.Remove(await Database.Ingredients.FirstAsync(x => x.Id == id));
            await Database.SaveChangesAsync();
        }

        public Task<List<Ingredient>> GetAsync(int skip, int take)
        {
            return Database.Ingredients
                .Include(x => x.IngredientRecipes)
                .OrderBy(x => x.Id).Skip(skip).Take(take)
                .ToListAsync();
        }

        public Task<Ingredient> GetByIdAsync(int id)
        {
            return Database.Ingredients
                .Include(x=>x.IngredientRecipes)
                .FirstAsync(x => x.Id == id);
        }

        public async Task<Ingredient> UpdateAsync(int id, string name, string category)
        {
            Ingredient toUpdate = await GetByIdAsync(id);
            toUpdate.Name = name;
            toUpdate.Category = category;
            await Database.SaveChangesAsync();
            return toUpdate;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            if (await Database.Ingredients.AnyAsync(p => p.Id == id))
            {
                return true;
            }
            else
                return false;
        }

        public Task<int> GetCountAsync()
        {
            return Database.Ingredients.CountAsync();
        }
    }
}

