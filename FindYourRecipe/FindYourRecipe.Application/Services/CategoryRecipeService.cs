using System;
using AutoMapper;
using FindYourRecipe.Application.Interfaces;
using FindYourRecipe.Application.Models;
using FindYourRecipe.Application.Models.Response;
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
    }
}

