using System;
using FindYourRecipe.DataAccess.Interfaces;

namespace FindYourRecipe.DataAccess.Services
{
	public class CategoryRecipeDataContext :ICategoryRecipeDataContext
	{
        public DataContext Database { get; }
		public CategoryRecipeDataContext(DataContext database)
		{
            Database = database;
		}

        public CategoryRecipe Create(int categoryId, int recipeId)
        {
            CategoryRecipe categoryRecipe = new CategoryRecipe()
            {
                CategoryId = categoryId,
                RecipeId = recipeId,
            };
            Database.Add(categoryRecipe);
            Database.SaveChanges();
            return categoryRecipe;
        }

        public void Delete(int id)
        {
            Database.Remove(Database.CategoryRecipes.First(x => x.Id == id));
        }

        public CategoryRecipe GetById(int id)
        {
            return Database.CategoryRecipes.First(x => x.Id == id);
        }

        public CategoryRecipe Update(int id, int categoryId, int recipeId)
        {
            CategoryRecipe toUpdate = GetById(id);
            toUpdate.CategoryId = categoryId;
            toUpdate.RecipeId = recipeId;
            Database.SaveChanges();
            return toUpdate;
        }

        public bool Exists(int id)
        {
            if (Database.CategoryRecipes.Any(p => p.Id == id))
            {
                return true;
            }
            else
                return false;
        }
    }
}

