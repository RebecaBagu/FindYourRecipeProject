using System;
namespace FindYourRecipe.Contracts.Models
{
	public class UserResponseModel
	{
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
    }
}

