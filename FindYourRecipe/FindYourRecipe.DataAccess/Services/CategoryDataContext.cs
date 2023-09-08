using System;
using FindYourRecipe.DataAccess.Interfaces;

namespace FindYourRecipe.DataAccess.Services
{
	public class CategoryDataContext :ICategoryDataContext
	{
		public DataContext Database { get; }
		public CategoryDataContext(DataContext database)
		{
			Database = database;
		}

        public Category GetById(int id)
        {
            return Database.Category.First(x => x.Id == id);
        }

        public Category Create(string name)
        {
            Category category = new Category()
            {
                Name = name,
            };
            Database.Add(category);
            Database.SaveChanges();
            return category;
        }

        public Category Update(int id, string name)
        {
            Category toUpdate = GetById(id);
            toUpdate.Name = name;
            Database.SaveChanges();
            return toUpdate;
        }

        public void Delete(int id)
        {
            Database.Remove(Database.Category.First(x => x.Id == id));
        }

        public bool Exists(int id)
        {
            if (Database.Category.Any(p => p.Id == id))
            {
                return true;
            }
            else
                return false;
        }
    }
}

