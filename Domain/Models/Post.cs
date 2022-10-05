namespace Domain;

public class Post
{
    public string Title { get; set; }
    
    public string BodyText { get; set; }
    
    public User Owner { get; set; }

    public int Id { get; set; }

}