namespace Domain.DTOs;

public class CreateUserDto
{
    public string Username { get; }
    public string Password { get; }

    public CreateUserDto(string username, string password)
    {
        Username = username;
        Password = password;
    }
}