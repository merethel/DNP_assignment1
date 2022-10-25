namespace Domain;

public class User
{
    public string Username { get; set; }
    public int Id { get; set; }
    public string Password { get; set; }
    
    public int SecurityLevel { get; set; }
}