using System;
using AutoMapper;
using FindYourRecipe.Contracts;
using FindYourRecipe.Contracts.Models;
using FindYourRecipe.DataAccess;
using FindYourRecipe.DataAccess.Interfaces;

namespace FindYourRecipe.Application.Services
{
	public class PhotoService :IPhotoService
	{
        readonly IRecipeRepository RecipeRepository;
        readonly IPhotoRepository Repository;
        readonly IMapper Mapper;
        public PhotoService(IPhotoRepository repository, IMapper mapper, IRecipeRepository recipeRepository)
        {
            Repository = repository;
            Mapper = mapper;
            RecipeRepository = recipeRepository;
        }

        public async Task<PhotoResponseModel> CreateAsync(CreatePhotoRequestModel request)
        {
            var photo= await Repository.CreateAsync(request.RecipeId,request.Link);
            return Mapper.Map<Photo, PhotoResponseModel>(photo);
        }

        public async Task DeteleAsync(int id)
        {
            if (await Repository.ExistsAsync(id))
                await Repository.DeteleAsync(id);
            else
                throw new NotFoundException(id);
        }

        public async Task<PhotoResponseModel> GetByIdAsync(int id)
        {
            if (await Repository.ExistsAsync(id))
            {
                var photo = await Repository.GetByIdAsync(id);
                return Mapper.Map<Photo, PhotoResponseModel>(photo);
            }
            else
                throw new NotFoundException(id);
        }

        public async Task<List<PhotoResponseModel>> GetByRecipeIdAsync(int recipeId)
        {
            if (await RecipeRepository.ExistsAsync(recipeId))
            {
                var photo = await Repository.GetByRecipeIdAsync(recipeId);
                return Mapper.Map<List<Photo>, List<PhotoResponseModel>>(photo);
            }
            else
                throw new NotFoundException(recipeId);
        }
    }
}

