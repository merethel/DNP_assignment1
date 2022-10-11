using Application.DaoInterfaces;
using Domain;

namespace FileData.DAOs;

public class PostFileDao : IPostDao
{
    private readonly FileContext Context;

    public PostFileDao(FileContext context)
    {
        Context = context;
    }

    public Task<Post> CreateAsync(Post post)
    {
        int postId = 1;
        if (Context.Posts.Any())
        {
            postId = Context.Posts.Max(p => p.Id);
            postId++;
        }

        post.Id = postId;
        
        Context.Posts.Add(post);
        Context.SaveChanges();

        return Task.FromResult(post);
    }

    public Task<IEnumerable<Post>> GetAsync()
    {
        IEnumerable<Post> result = Context.Posts.AsEnumerable();
        return Task.FromResult(result);
    }

    public Task<Post> GetById(int id)
    {
        Post? post = Context.Posts.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(post);
    }
}