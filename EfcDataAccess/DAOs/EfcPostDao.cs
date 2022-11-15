using Application.DaoInterfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class EfcPostDao : IPostDao
{
    private readonly RedditContext context;
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
        Post? post = await context.Posts.FindAsync(id);
        return post;
    }
}