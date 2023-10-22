using System;
using AutoMapper;
using FindYourRecipe.Contracts;
using FindYourRecipe.Contracts.Models;
using FindYourRecipe.DataAccess;
using FindYourRecipe.DataAccess.Interfaces;

namespace FindYourRecipe.Application.Services
{
	public class IngredientRecipeService : IIngredientRecipeService
	{
		IIngredientRecipeRepository Repository;
		IMapper Mapper;
		public IngredientRecipeService(IIngredientRecipeRepository repository, IMapper mapper)
		{
            Repository = repository;
            Mapper = mapper;
		}

        public async Task<IngredientRecipeResponseModel> CreateAsync(CreateIngredientRecipeRequestModel request)
        {
            var ingredientRecipe = await Repository.CreateAsync(request.IngredientId, request.RecipeId, request.Quantity);
            return Mapper.Map<IngredientRecipe, IngredientRecipeResponseModel>(ingredientRecipe);
        }

        public async Task DeleteAsync(int id)
        {
            if (await Repository.ExistsAsync(id))
                await Repository.DeleteAsync(id);
            else
                throw new NotFoundException(id);
        }

        public async Task<IngredientRecipeResponseModel> UpdateAsync(int id,CreateIngredientRecipeRequestModel request)
        {
            var ingredientRecipe = await Repository.UpdateAsync(id,request.IngredientId, request.RecipeId, request.Quantity);
            return Mapper.Map<IngredientRecipe, IngredientRecipeResponseModel>(ingredientRecipe);
        }

        public async Task DeleteByRecipeIdAsync(int recipeId)
        {
            await Repository.DeleteByRecipeIdAsync(recipeId);
        }


    }
}

