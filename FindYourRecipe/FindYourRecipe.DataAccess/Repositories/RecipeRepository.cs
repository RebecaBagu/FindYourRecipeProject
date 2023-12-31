﻿using System;
using Microsoft.EntityFrameworkCore;

namespace FindYourRecipe.DataAccess.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        public DataContext Database { get; }

        public RecipeRepository(DataContext database)
        {
            Database = database;
        }

        public async Task<Recipe> CreateAsync(string title, string description, string cuisine, string dificulty, string recipeLink)
        {
            Recipe recipe = new Recipe()
            {
                Title = title,
                Description = description,
                Cuisine = cuisine,
                Dificulty = dificulty,
                RecipeLink = recipeLink,
            };
            Database.Add(recipe);
            await Database.SaveChangesAsync();
            return recipe;

        }

        public async Task DeleteByIdAsync(int id)
        {
            Database.Remove(await Database.Recipes.FirstAsync(x => x.Id == id));
            await Database.SaveChangesAsync();
        }

        public Task<List<Recipe>> GetAsync()
        {
            return Database.Recipes
                .Include(p => p.Photos)
                .Include(p => p.CategoryRecipes).ThenInclude(p=>p.Category)
                .Include(p=>p.IngredientRecipes).ThenInclude(p=>p.Ingredient)
                .OrderBy(p => p.Id).ToListAsync();
        }

        public Task<Recipe> GetByIdAsync(int id)
        {
            return Database.Recipes
                .Include(p => p.Photos)
                .Include(p => p.CategoryRecipes).ThenInclude(p => p.Category)
                .Include(p => p.IngredientRecipes).ThenInclude(p => p.Ingredient)
                .SingleAsync(x => x.Id == id);
        }

        public async Task<Recipe> UpdateAsync(int id, string title, string description, string cuisine, string dificulty, string recipeLink)
        {
            Recipe toUpdate = await GetByIdAsync(id);
            toUpdate.Title = title;
            toUpdate.Description = description;
            toUpdate.Cuisine = cuisine;
            toUpdate.Dificulty = dificulty;
            toUpdate.RecipeLink = recipeLink;
            await Database.SaveChangesAsync();
            return toUpdate;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            if (await Database.Recipes.AnyAsync(p => p.Id == id))
                return true;
            else
                return false;
        }

        public async Task<List<Recipe>> GetByIngredientsAsync(List<int> ingredientIds)
        {
            if (ingredientIds.Count == 0)
            { 
                return await GetAsync();
            }
            else
            {
                var recipes = from recipe in Database.Recipes
                              join ingredirntRecipe in Database.IngredientsRecipes on recipe.Id equals ingredirntRecipe.RecipeId
                              where ingredientIds.Contains(ingredirntRecipe.IngredientId)
                              group recipe by recipe into Recipes
                              where Recipes.Count() >= ingredientIds.Count
                              select Recipes.Key.Id;
                var recipesIds = await recipes.ToListAsync();
                var selectedRecipes = Database.Recipes
                    .Include(x=>x.Photos)
                    .Include(p => p.CategoryRecipes).ThenInclude(p => p.Category)
                    .Where(x => recipesIds
                    .Contains(x.Id));
                return await selectedRecipes.ToListAsync();
            }
        }
    }
}

