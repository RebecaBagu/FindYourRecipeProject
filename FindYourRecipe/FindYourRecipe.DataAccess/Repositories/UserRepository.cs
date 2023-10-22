using System;
using System.Text;
using FindYourRecipe.DataAccess.Entities;
using FindYourRecipe.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FindYourRecipe.DataAccess.Repositories
{
	public class UserRepository: IUserRepository
	{
        public DataContext Database { get; }
        public const string Salt = "gIdUs4jmHT0BhsBgUhzxqA2tzH6DRS0r";

        public UserRepository(DataContext database)
        {
            Database = database;
        }

        public static string sha256(string password)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(password));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

        public async Task<User> CreateAsync(string username, string name, string email, string password)
        {
            User user = new User()
            {
                Username = username,
                Name = name,
                Email = email,
                Password = sha256(Salt+password),
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

        public async  Task<List<User>> GetAsync()
        {
            var list=  await Database.Users.OrderBy(x => x.Id).ToListAsync();
            return list;
        }

        public async Task<User?> GetByUsername(string username)
        {
            return await Database.Users
                .Include(x=>x.Role)
                .FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<User> Update(int id, string name, string email, string password)
        {
            var userToUpdate = await Database.Users.FirstAsync(x => x.Id == id);
            userToUpdate.Name = name;
            userToUpdate.Email = email;
            userToUpdate.Password = sha256(Salt + password);
            await Database.SaveChangesAsync();
            return userToUpdate;
        }

        public Task<User> GetByIdAsync(int id)
        {
            return Database.Users.FirstAsync(x => x.Id == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            if (await Database.Users.AnyAsync(p => p.Id == id))
                return true;
            else
                return false;
        }
    }
}

