using System;
using AutoMapper;
using FindYourRecipe.Application.Interfaces;
using FindYourRecipe.Application.Models;
using FindYourRecipe.Application.Services;
using FindYourRecipe.DataAccess;

namespace FindYourRecipe.Application.Services
{
	public class RecipeService:IRecipeService
	{
        readonly IRecipeRepository Repository;
        readonly IMapper Mapper;
		public RecipeService(IRecipeRepository repository, IMapper mapper)
		{
            Repository = repository;
            Mapper = mapper;
		}

        public async Task<RecipeResponseModel> CreateAsync(CreateOrUpdateRecipeRequestModel requestModel)
        {
            var recipe = await Repository.CreateAsync(requestModel.Title, requestModel.Description, requestModel.Cuisine, requestModel.Dificulty, requestModel.RecipeLink);
            return Mapper.Map<Recipe, RecipeResponseModel>(recipe);
        }

        public async Task DeleteAsync(int id)
        {
            if (await Repository.ExistsAsync(id))
                await Repository.DeleteByIdAsync(id);
            else
                throw new NotFoundException(id);
        }

        public async Task<List<RecipeResponseModel>> GetAsync()
        {
            var recipes = await Repository.GetAsync();
            return Mapper.Map<List<Recipe>, List<RecipeResponseModel>>(recipes);
        }

        public async Task<RecipeResponseModel> GetByIdAsync(int id)
        {
            if (await Repository.ExistsAsync(id))
            {
                var recipe = await Repository.GetByIdAsync(id);
                return Mapper.Map<Recipe, RecipeResponseModel>(recipe);
            }
            else
                throw new NotFoundException(id);
        }

        public async Task<List<RecipeResponseModel>> GetByIngredientsAsync(List<int> ingredientsIds)
        {
            var recipes = await Repository.GetByIngredientsAsync(ingredientsIds);
            return Mapper.Map<List<Recipe>, List<RecipeResponseModel>>(recipes);
        }

        public async Task<RecipeResponseModel> UpdateAsync(int id, CreateOrUpdateRecipeRequestModel requestModel)
        {
            if (await Repository.ExistsAsync(id))
            {
                var recipe = await Repository.UpdateAsync(id, requestModel.Title, requestModel.Description, requestModel.Cuisine, requestModel.Dificulty, requestModel.RecipeLink);
                return Mapper.Map<Recipe, RecipeResponseModel>(recipe);
            }
            else
                throw new NotFoundException(id);
        }
    }
}
