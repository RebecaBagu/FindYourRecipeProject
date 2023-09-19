using System;
using AutoMapper;
using FindYourRecipe.Application.Models.Ingredients;
using FindYourRecipe.DataAccess;

namespace FindYourRecipe.Application
{
	public class MapperProfile :Profile
	{
		public MapperProfile()
		{
           
            CreateMap<Ingredient, IngredientResponseModel>();
			CreateMap<Recipe, RecipeResponseModel>();
			CreateMap<Photo, PhotoResponseModel>();
		}
	}
}

