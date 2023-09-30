using System;
using AutoMapper;
using FindYourRecipe.Contracts;
using FindYourRecipe.Contracts.Models;
using FindYourRecipe.DataAccess;
using FindYourRecipe.DataAccess.Interfaces;

namespace FindYourRecipe.Application.Services
{
	public class CategoryRecipeService:ICategoryRecipeService
	{
        ICategoryRecipeRepository Repository;
        IMapper Mapper;
		public CategoryRecipeService(ICategoryRecipeRepository repository, IMapper mapper)
		{
            Repository = repository;
            Mapper = mapper;
		}

        public async Task<CategoryRecipeResponseModel> CreateAsync(CreateCategoryRecipeRequestModel request)
        {
            var categoryRecipe = await Repository.CreateAsync(request.CategoryId, request.RecipeId);
            return Mapper.Map<CategoryRecipe, CategoryRecipeResponseModel>(categoryRecipe);
        }

        public async Task DeleteAsync(int id)
        {
            if (await Repository.ExistsAsync(id))
                await Repository.DeleteAsync(id);
            else
                throw new NotFoundException(id);
        }

        public async Task<CategoryRecipeResponseModel> GetByIdAsync(int id)
        {
            if (await Repository.ExistsAsync(id))
            {
                var categoryRecipe= await Repository.GetByIdAsync(id);
                return Mapper.Map<CategoryRecipe,CategoryRecipeResponseModel>(categoryRecipe);
            }
            else
                throw new NotFoundException(id);
        }

        public async Task<List<CategoryRecipeResponseModel>> GetAsync()
        {
            var categoryRecipes=await Repository.GetAsync();
            return Mapper.Map<List<CategoryRecipe>, List<CategoryRecipeResponseModel>>(categoryRecipes);
        }
    }
}

