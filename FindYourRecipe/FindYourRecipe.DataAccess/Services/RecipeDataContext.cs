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

        public Recipe Create(string title, string description, string cuisine, string dificulty)
        {
            Recipe recipe = new Recipe()
            {
                Title = title,
                Description = description,
                Cuisine = cuisine,
                Dificulty=dificulty,
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

        public Recipe Update(int id, string title, string description, string cuisine, string dificulty)
        {
            Recipe toUpdate = GetById(id);
            toUpdate.Title = title;
            toUpdate.Description = description;
            toUpdate.Cuisine = cuisine;
            toUpdate.Dificulty = dificulty;
            Database.SaveChanges();
            return toUpdate;
        }
    }
}

