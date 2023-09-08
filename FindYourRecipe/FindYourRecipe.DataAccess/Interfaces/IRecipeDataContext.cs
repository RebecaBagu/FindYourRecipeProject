﻿using System;
namespace FindYourRecipe.DataAccess
{
	public interface IRecipeDataContext
	{
		public Recipe GetById(int id);

        public List<Recipe> Get();

        public Recipe Create(string title, string description,string cuisine, string dificulty, string recipeLink);

        public  void DeleteById(int id);

        public  Recipe Update(int id, string title, string description, string cuisine, string dificulty, string recipeLink);

        public bool Exists(int id);

        public List<Recipe> GetByIngredients(List<int> ingredientIds);

	}
}

