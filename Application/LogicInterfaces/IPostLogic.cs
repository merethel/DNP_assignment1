using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreateAsync(CreatePostDto postDto);
    Task<IEnumerable<Post>> GetAsync();
    Task<Post?> GetById(int id);
}