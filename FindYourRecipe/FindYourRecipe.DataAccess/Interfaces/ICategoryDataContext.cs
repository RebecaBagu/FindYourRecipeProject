using System;
namespace FindYourRecipe.DataAccess.Interfaces
{
	public interface ICategoryDataContext
	{
		public Category GetById(int id);
		public Category Create(string name);
		public Category Update(int id, string name);
		public void Delete(int id);
	}
}

