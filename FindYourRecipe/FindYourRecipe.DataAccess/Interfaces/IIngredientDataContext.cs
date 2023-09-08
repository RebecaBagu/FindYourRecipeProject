using System;
namespace FindYourRecipe.DataAccess.Interfaces
{
	public interface IIngredientDataContext
	{
		public Ingredient GetById(int id);

		public List<Ingredient> Get();

		public Ingredient Create(string name, string category);

		public void DeleteById(int id);

		public Ingredient Update(int id,string name, string category);

        public bool Exists(int id);
    }
}

