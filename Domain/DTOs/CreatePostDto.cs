namespace Domain.DTOs;

public class CreatePostDto
{
    public int Owner { get; }
    
    public string Title { get; }
    
    public string BodyText { get; }

    public CreatePostDto(int owner, string title, string bodyText)
    {
        Owner = owner;
        Title = title;
        BodyText = bodyText;
    }
}