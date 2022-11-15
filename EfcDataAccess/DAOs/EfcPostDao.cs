using Application.DaoInterfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class EfcPostDao : IPostDao
{
    private readonly RedditContext context;
    
    public EfcPostDao(RedditContext context)
    {
        this.context = context;
    }
    public async Task<Post> CreateAsync(Post post)
    {
        EntityEntry<Post> added = await context.Posts.AddAsync(post);
        await context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task<IEnumerable<Post>> GetAsync()
    {
        IQueryable<Post> posts = context.Posts.Include(post => post.Owner).AsQueryable();
        IEnumerable<Post> result = await posts.ToListAsync();
        return result;
    }

    public async Task<Post> GetById(int id)
    {
        IQueryable<Post> posts = context.Posts.Include(post => post.Owner).AsQueryable();
        Task<Post?> post = posts.FirstOrDefaultAsync(post => post.Id == id);
        return post.Result;
    }
}