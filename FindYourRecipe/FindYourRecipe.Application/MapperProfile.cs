using System;
using AutoMapper;
using FindYourRecipe.Application.Models;
using FindYourRecipe.Application.Models.Response;
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

