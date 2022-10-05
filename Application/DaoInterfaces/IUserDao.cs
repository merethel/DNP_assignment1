using Domain;

namespace Application.DaoInterfaces;
//hejMerethe

public interface IUserDao
{
    Task<User> CreateAsync(User user);
    Task<User?> GetByUsernameAsync(string username);
    Task<User?> GetByIdAsync(int id);
}