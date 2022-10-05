namespace Domain.DTOs;
//Test af jakob i en ny branch
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