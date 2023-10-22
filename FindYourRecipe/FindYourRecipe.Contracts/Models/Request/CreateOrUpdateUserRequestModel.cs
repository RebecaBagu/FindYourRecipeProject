using System;
namespace FindYourRecipe.Contracts.Models.Request
{
	public class CreateOrUpdateUserRequestModel
	{
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

