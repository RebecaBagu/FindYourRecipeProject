using System;
using AutoMapper;
using FindYourRecipe.Contracts;
using FindYourRecipe.Contracts.Models.Request;
using FindYourRecipe.Contracts.Models.Response;
using FindYourRecipe.DataAccess;
using FindYourRecipe.DataAccess.Entities;
using FindYourRecipe.DataAccess.Interfaces;
using Microsoft.Extensions.Configuration;
using PizzaApp.Application.Helpers;

namespace FindYourRecipe.Application.Services
{
	public class UserService :IUserService
	{
        readonly IUserRepository Repository;
        readonly IMapper Mapper;
        readonly IConfiguration Configuration;
        public UserService(IUserRepository repository, IMapper mapper ,IConfiguration configuration)
        {
            Repository = repository;
            Mapper = mapper;
            Configuration = configuration;
        }

        public async Task<UserResponseModel> CreateAsync(CreateOrUpdateUserRequestModel request)
        {
            var user = await Repository.CreateAsync(request.Username, request.Name,request.Email, request.Password);
            return Mapper.Map<User, UserResponseModel>(user);
        }

        public async Task Delete(int id)
        {
            await Repository.DeleteByIdAsync(id);
        }

        public async Task<List<UserResponseModel>> GetAsync()
        {
            var usersList = await Repository.GetAsync();
            return Mapper.Map<List<User>, List<UserResponseModel>>(usersList);
        }

        public async Task<LoginResponseModel> LoginAsync(LoginRequestModel requestModel)
        {
            var user = await Repository.GetByUsername(requestModel.Username);
            if (user == null)
            {
                throw new NotFoundException("Username or password is incorrect.");
            }
            if (user.Password != requestModel.Password)
            {
                throw new NotFoundException("Username or password is incorrect.");
            }

            var token = JwtHelper.GenerateToken(user, Configuration["SecurityKey"]);

            return new LoginResponseModel
            {
                Username = user.Username,
                Id = user.Id,
                Email = user.Email,
                Token = token
            };

        }

        public async Task<UserResponseModel> Update(int id, CreateOrUpdateUserRequestModel request)
        {
            var userToUpdate =await  Repository.Update(id, request.Name, request.Email, request.Password);
            return Mapper.Map<User, UserResponseModel>(userToUpdate);
        }
    }
}

