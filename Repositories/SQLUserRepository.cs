using medic_api.Data;
using medic_api.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace medic_api.Repositories
{
    public class SQLUserRepository : IUserRepository
    {
        private readonly ApplicationDbContext dbContext;
        public SQLUserRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<List<User>> GetAllUsers()
        {
            return await dbContext.Users.ToListAsync();
        }

        public async Task<User> GetById(int Id)
        {
            return await dbContext.Users.FindAsync(Id);
        }
        public async Task BlockUser(User user)
        {
            dbContext.Users.Update(user);
            await dbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserByUsernameAndPassword(string username, string password)
        {
            return await dbContext.Users.FirstOrDefaultAsync(u => u.Username == username && u.PasswordHash == password);
        }

        public async Task RegisterUser(User user)
        {
            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();
        }
    }
}
