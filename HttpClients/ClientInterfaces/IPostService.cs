using Domain;
using Domain.DTOs;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task<Post> CreatePost(CreatePostDto dto);

}