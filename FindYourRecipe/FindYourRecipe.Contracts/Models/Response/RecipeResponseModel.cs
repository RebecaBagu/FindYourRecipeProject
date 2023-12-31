﻿using System;
namespace FindYourRecipe.Contracts.Models
{
	public class RecipeResponseModel
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Cuisine { get; set; }
        public string Dificulty { get; set; }
        public string RecipeLink { get; set; }

        public List<PhotoResponseModel> Photos { get; set; }
        public List<CategoryRecipeResponseModel> CategoryRecipes { get; set; }
        public List<IngredientRecipeResponseModel> IngredientRecipes { get; set; }
        

    }
}

