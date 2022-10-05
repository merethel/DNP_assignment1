
using Application.DaoInterfaces;
using Domain;


namespace FileData.DAOs;

public class UserFileDao : IUserDao
{
    private readonly FileContext Context;

    public UserFileDao(FileContext context)
    {
        Context = context;
    }

    public Task<User> CreateAsync(User user)
    {
        int userId = 1;
        if (Context.Users.Any())
        {
            userId = Context.Users.Max(u => u.Id);
            userId++;
        }

        user.Id = userId;

        Context.Users.Add(user);
        Context.SaveChanges();

        return Task.FromResult(user);
    }
    
    public Task<User?> GetByUsernameAsync(string username)
    {
        User? user = Context.Users.FirstOrDefault(u => u.Username.Equals(username,StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(user);
    }

    public Task<User?> GetByIdAsync(int id)
    {
        User? existing = Context.Users.FirstOrDefault(u => u.Id == id);
        return Task.FromResult(existing);
    }
}