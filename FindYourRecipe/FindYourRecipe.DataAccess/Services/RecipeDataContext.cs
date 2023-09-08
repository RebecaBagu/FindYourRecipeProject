using System;

namespace FindYourRecipe.DataAccess.Services
{
	public class RecipeDataContext : IRecipeDataContext
    {
        public DataContext Database { get; }

        public RecipeDataContext(DataContext database)
		{
            Database = database;
        }

        public Recipe Create(string title, string description, string cuisine, string dificulty, string recipeLink)
        {
            Recipe recipe = new Recipe()
            {
                Title = title,
                Description = description,
                Cuisine = cuisine,
                Dificulty=dificulty,
                RecipeLink=recipeLink,
            };
            Database.Add(recipe);
            Database.SaveChanges();
            return recipe;
            
        }

        public void DeleteById(int id)
        {
            Database.Remove(Database.Recipes.First(x => x.Id == id));
            Database.SaveChanges();
        }

        public List<Recipe> Get()
        {
            return Database.Recipes.OrderBy(p => p.Id).ToList();
        }

        public Recipe GetById(int id)
        {
            return Database.Recipes.Single(x=>x.Id==id);
        }

        public Recipe Update(int id, string title, string description, string cuisine, string dificulty, string recipeLink)
        {
            Recipe toUpdate = GetById(id);
            toUpdate.Title = title;
            toUpdate.Description = description;
            toUpdate.Cuisine = cuisine;
            toUpdate.Dificulty = dificulty;
            toUpdate.RecipeLink = recipeLink;
            Database.SaveChanges();
            return toUpdate;
        }

        public bool Exists(int id)
        {
            if (Database.Recipes.Any(p => p.Id == id))
            {
                return true;
            }
            else
                return false;
        }

        public List<Recipe> GetByIngredients(List<int> ingredientIds)
        {
            var recipes = from recipe in Database.Recipes
                          join ingredirntRecipe in Database.IngredientsRecipes on recipe.Id equals ingredirntRecipe.RecipeId
                          where ingredientIds.Contains(ingredirntRecipe.IngredientId)
                          group recipe by recipe into Recipes
                          where Recipes.Count() >= ingredientIds.Count
                          select Recipes.Key;
            return recipes.ToList();
        }
    }
}

