using System;
using FindYourRecipe.DataAccess.Entities;
using FindYourRecipe.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FindYourRecipe.DataAccess.Repositories
{
	public class UserRepository: IUserRepository
	{
        public DataContext Database { get; }

        public UserRepository(DataContext database)
        {
            Database = database;
        }

        public async Task<User> CreateAsync(string username, string name, string email, string password)
        {
            User user = new User()
            {
                Username = username,
                Name = name,
                Email = email,
                Password = password,
                RoleId=2
            };
            Database.Add(user);
            await Database.SaveChangesAsync();
            return user;

        }

        public async Task DeleteByIdAsync(int id)
        {
            Database.Remove(await Database.Users.FirstAsync(x => x.Id == id));
            await Database.SaveChangesAsync();
        }

        public Task<List<User>> GetAsync()
        {
            return Database.Users.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<User> GetByUsername(string username)
        {
            return await Database.Users.FirstAsync(x => x.Username == username);
        }

        public async Task<User> Update(int id, string name, string email, string password)
        {
            var userToUpdate = await Database.Users.FirstAsync(x => x.Id == id);
            userToUpdate.Name = name;
            userToUpdate.Email = email;
            userToUpdate.Password = password;
            await Database.SaveChangesAsync();
            return userToUpdate;
        }
    }
}

