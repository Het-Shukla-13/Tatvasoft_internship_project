using MyProject.Entities.Models;
using MyProject.Entities;
using MyProject.Repositories.IRepository;

namespace MyProject.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MyProjectDbContext _context;

        public UserRepository(MyProjectDbContext context)
        {
            _context = context;
        }

        public User? GetUserByEmailAndPassword(string email, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}
