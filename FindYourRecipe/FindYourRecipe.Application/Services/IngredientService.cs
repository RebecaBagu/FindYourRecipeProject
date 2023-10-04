using System;
using AutoMapper;
using FindYourRecipe.Contracts;
using FindYourRecipe.Contracts.Models;
using FindYourRecipe.DataAccess;
using FindYourRecipe.DataAccess.Interfaces;
using FindYourRecipe.DataAccess.Repositories;

namespace FindYourRecipe.Application.Services
{
	public class IngredientService : IIngredientService
	{
        private readonly IIngredientRepository Repository;
        private readonly IMapper Mapper;
		public IngredientService(IIngredientRepository repository, IMapper mapper)
		{
            Repository = repository;
            Mapper = mapper;
		}

        public async Task<IngredientResponseModel> CreateAsync(CreateOrUpdateIngredientRequestModel requestModel)
        {
            var ingredient = await Repository.CreateAsync(requestModel.Name, requestModel.Category);
            return Mapper.Map<Ingredient, IngredientResponseModel>(ingredient);
        }

        public async Task DeleteAsync(int id)
        {
            if (await Repository.ExistsAsync(id))
                await Repository.DeleteByIdAsync(id);
            else
                throw new NotFoundException(id) ;
        }

        

        public async Task<List<IngredientResponseModel>> GetAsync(int skip, int take)
        {
            var ingredientsList =await  Repository.GetAsync(skip,take);
            return Mapper.Map<List<Ingredient>, List<IngredientResponseModel>>(ingredientsList);
        }

        public async Task<IngredientResponseModel> GetByIdAsync(int id)
        {
            if (await Repository.ExistsAsync(id))
            {
                Ingredient ingredient = await Repository.GetByIdAsync(id);
                return Mapper.Map<Ingredient, IngredientResponseModel>(ingredient);
            }
            else
                throw new NotFoundException(id);
        }

        public async Task<IngredientResponseModel> UpdateAsync(int id,CreateOrUpdateIngredientRequestModel requestModel)
        {
            if (await Repository.ExistsAsync(id))
            {
                var ingredient = await Repository.UpdateAsync(id, requestModel.Name, requestModel.Category);
                return Mapper.Map<Ingredient, IngredientResponseModel>(ingredient);
            }
            else
                throw new NotFoundException(id);


        }
        public async Task<int> GetCountAsync()
        {
            return await Repository.GetCountAsync();
        }
    }
}

