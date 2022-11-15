using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Post
{
    public string Title { get; set; }

    public string BodyText { get; set; }

    public User Owner { get; set; }

    [Key]
    public int Id { get; set; }
    
    public Post(string title, string bodyText, User owner)
    {
        Title = title;
        BodyText = bodyText;
        Owner = owner;
    }

    public Post()
    {
    }
}