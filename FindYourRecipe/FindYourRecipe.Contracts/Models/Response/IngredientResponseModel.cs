﻿using System;
namespace FindYourRecipe.Contracts.Models
{
	public class IngredientResponseModel
	{
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public ICollection<IngredientRecipeResponseModel> IngredientRecipe { get; set; }
    }
}

