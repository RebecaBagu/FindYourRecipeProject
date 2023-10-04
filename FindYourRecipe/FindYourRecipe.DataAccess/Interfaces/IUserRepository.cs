using System;
using FindYourRecipe.DataAccess.Entities;

namespace FindYourRecipe.DataAccess.Interfaces
{
	public interface IUserRepository
	{
		public Task<User> CreateAsync(string username, string name, string email, string password);
		public Task DeleteByIdAsync(int id);
		public Task<List<User>> GetAsync();
		public Task<User> GetByUsername(string username);
		public Task<User> Update(int id,string name, string email,string password);
	}
}

