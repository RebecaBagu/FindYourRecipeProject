using System;
namespace FindYourRecipe.Contracts.Models.Response
{
	public class LoginResponseModel
	{
        public string Username { get; set; }

        public int Id { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }
    }
}

