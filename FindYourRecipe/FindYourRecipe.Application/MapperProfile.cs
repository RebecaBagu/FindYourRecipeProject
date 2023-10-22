using System;
using AutoMapper;
using FindYourRecipe.Contracts.Models;
using FindYourRecipe.Contracts.Models.Response;
using FindYourRecipe.DataAccess;
using FindYourRecipe.DataAccess.Entities;

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
			CreateMap<User, UserResponseModel>();
		}
	}
}

