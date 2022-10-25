using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao userDao;

    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }

    public async Task<User> CreateAsync(CreateUserDto dto)
    {
        User? existing = await userDao.GetByUsernameAsync(dto.Username);
        if (existing != null)
            throw new Exception("Username already taken!");

        ValidateData(dto);
        User toCreate = new User
        {
            Username = dto.Username,
            Password = dto.Password
        };
        
        User created = await userDao.CreateAsync(toCreate);
        
        return created;
    }

    public async Task<User> ValidateUser(string username, string password)
    {
        User? existingUser = await userDao.GetByUsernameAsync(username);
        if (existingUser == null)
        {
            throw new Exception($"User by name {username} does not exist");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Password is not correct");
        }

        return await Task.FromResult(existingUser);
    }


    private static void ValidateData(CreateUserDto userToCreate)
    {
        string Username = userToCreate.Username;
        string Password = userToCreate.Password;

        if (Username.Length < 3)
            throw new Exception("Username must be at least 3 characters!");

        if (Username.Length > 15)
            throw new Exception("Username must be less than 16 characters!");

        if (Password.Length<8)
        {
            throw new Exception("Password must be greater than 8 characters");
        }
        
    }

}