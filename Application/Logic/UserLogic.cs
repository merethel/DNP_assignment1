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
            Username = dto.Username
        };
        
        User created = await userDao.CreateAsync(toCreate);
        
        return created;
    }
    

    private static void ValidateData(CreateUserDto userToCreate)
    {
        string userName = userToCreate.Username;

        if (userName.Length < 3)
            throw new Exception("Username must be at least 3 characters!");

        if (userName.Length > 15)
            throw new Exception("Username must be less than 16 characters!");
    }

}