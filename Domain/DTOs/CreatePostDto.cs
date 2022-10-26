namespace Domain.DTOs;

public class CreatePostDto
{
    public string OwnerUsername { get; }
    
    public string Title { get; }
    
    public string BodyText { get; }

    public CreatePostDto(string ownerUsername, string title, string bodyText)
    {
        OwnerUsername = ownerUsername;
        Title = title;
        BodyText = bodyText;
    }
}