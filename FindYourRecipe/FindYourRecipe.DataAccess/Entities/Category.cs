﻿using System;
namespace FindYourRecipe.DataAccess
{
	public class Category
	{
		public int Id { get; set; }
		public string Name { get; set; }

        public IList<CategoryRecipe> CategoryRecipes { get; set; }
    }
}

