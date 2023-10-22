using System;
using FindYourRecipe.Application;
using FindYourRecipe.Application.Services;
using FindYourRecipe.Contracts;
using FindYourRecipe.Contracts.Models;
using FindYourRecipe.Contracts.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindYourRecipe.Api.Controllers
{
    [ApiController]
    [Route("users")]
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        IUserService UserService { get; }
        public UserController(IUserService userService)
        {
            UserService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await UserService.GetAsync());

        }

        [HttpGet("{id})")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await UserService.GetByIdAsync(id));

            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await UserService.Delete(id);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

		[HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync(LoginRequestModel request)
		{
            try
            {
                var response = await UserService.LoginAsync(request);

                return Ok(response);
            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUserAsync(CreateOrUpdateUserRequestModel request)
        {
            var response = await UserService.CreateAsync(request);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateAsync(int id, CreateOrUpdateUserRequestModel request)
        {
            try
            {
                return Ok(await UserService.UpdateAsync(id, request));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

    }
	
}

