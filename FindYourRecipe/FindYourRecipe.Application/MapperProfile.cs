using System;
using AutoMapper;
using FindYourRecipe.Contracts.Models;
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
			CreateMap<Category, CategoryResponseModel>();
			CreateMap<IngredientRecipe, IngredientRecipeResponseModel>();
			CreateMap<CategoryRecipe, CategoryRecipeResponseModel>();
		}
	}
}

