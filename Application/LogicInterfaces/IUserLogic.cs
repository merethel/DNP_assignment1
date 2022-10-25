using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    Task<User> CreateAsync(CreateUserDto userToCreate);
    Task<User> ValidateUser(string username, string password);
}