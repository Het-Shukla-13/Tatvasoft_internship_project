using MyProject.Entities.Models;

namespace MyProject.Repositories.IRepository
{
    public interface IUserRepository
    {
        User? GetUserByEmailAndPassword(string email, string password);
    }
}
