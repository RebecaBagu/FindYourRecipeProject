﻿using System;
using AutoMapper;
using FindYourRecipe.Application.Interfaces;
using FindYourRecipe.Application.Models.Request;
using FindYourRecipe.Application.Models.Response;
using FindYourRecipe.DataAccess;
using FindYourRecipe.DataAccess.Interfaces;

namespace FindYourRecipe.Application.Services
{
	public class CategoryService: ICategoryService
	{
        ICategoryRepository Repository;
        IMapper Mapper;

		public CategoryService(ICategoryRepository repository, IMapper mapper)
		{
            Repository = repository;
            Mapper = mapper;
		}

        public async Task<CategoryResponseModel> CreateAsync(CreateOrUpdateCategoryRequestModel request)
        {
            var category = await Repository.CreateAsync(request.Name);
            return Mapper.Map<Category, CategoryResponseModel>(category);
        }

        public async Task DeleteAsync(int id)
        {
            if (await Repository.ExistsAsync(id))
                await Repository.DeleteAsync(id);
            else
                throw new NotFoundException(id);

        }

        public async Task<CategoryResponseModel> GetByIdAsync(int id)
        {
            if (await Repository.ExistsAsync(id))
            {
                var category = await Repository.GetByIdAsync(id);
                return Mapper.Map<Category, CategoryResponseModel>(category);
            }
            else
                throw new NotFoundException(id);
        }

        public async Task<CategoryResponseModel> UpdateAsync(int id, CreateOrUpdateCategoryRequestModel request)
        {
            if (await Repository.ExistsAsync(id))
            {
                var category = await Repository.UpdateAsync(id, request.Name);
                return Mapper.Map<Category, CategoryResponseModel>(category);
            }
            else
                throw new NotFoundException(id);
        }
    }
}

