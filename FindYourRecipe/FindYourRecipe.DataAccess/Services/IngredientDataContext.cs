using System;
using FindYourRecipe.DataAccess.Interfaces;

namespace FindYourRecipe.DataAccess.Services
{
	public class IngredientDataContext :IIngredientDataContext
	{
        public DataContext Database { get; }
		public IngredientDataContext(DataContext database)
		{
            Database = database;
		}

        public Ingredient Create(string name, string category)
        {
            Ingredient ingredient = new Ingredient()
            {
                Name=name,
                Category=category,
            };
            Database.Add(ingredient);
            Database.SaveChanges();
            return ingredient;
        }

        public void DeleteById(int id)
        {
            Database.Remove(Database.Ingredients.First(x => x.Id == id));
            Database.SaveChanges();
        }

        public List<Ingredient> Get()
        {
            return Database.Ingredients.OrderBy(x => x.Id).ToList();
        }

        public Ingredient GetById(int id)
        {
            return Database.Ingredients.First(x => x.Id == id);
        }

        public Ingredient Update(int id, string name, string category)
        {
            Ingredient toUpdate = GetById(id);
            toUpdate.Name = name;
            toUpdate.Category = category;
            Database.SaveChanges();
            return toUpdate;
        }

        public bool Exists(int id)
        {
            if (Database.Ingredients.Any(p => p.Id == id))
            {
                return true;
            }
            else
                return false;
        }
    }
}

