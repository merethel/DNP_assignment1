using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao PostDao;
    private readonly IUserDao UserDao;

    public PostLogic(IPostDao postDao, IUserDao userDao)
    {
        PostDao = postDao;
        UserDao = userDao;

    }

    public async Task<Post> CreateAsync(CreatePostDto postDto)
    {
       ValidateData(postDto);

       User? user = await UserDao.GetByIdAsync(postDto.Owner);
       Post toCreate = new Post
       {
           Owner = user,
           Title = postDto.Title,
           BodyText = postDto.BodyText
       };

       Post created = await PostDao.CreateAsync(toCreate);
       
       return created;

    }

    private static void ValidateData(CreatePostDto postDto)
    {
        if (postDto.Owner == null)
        {
            throw new Exception("Post must have an owner");
        }

        if (string.IsNullOrEmpty(postDto.Title))
        {
            throw new Exception("You must have a title");
        }

        if (postDto.Title.Length > 300)
        {
            throw new Exception("Title too long. Must be 300 characters or less");
        }

        if (postDto.BodyText.Length>10000)
        {
            throw new Exception("Post too long. Must be 10.000 characters or less");
        }
        
        if (string.IsNullOrEmpty(postDto.BodyText))
        {
            throw new Exception("You can't have an empty post");
        }
        
    }
}