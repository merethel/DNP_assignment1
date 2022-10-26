using System.Net.Http.Json;
using System.Text.Json;
using Domain;
using Domain.DTOs;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class PostService : IPostService
{
    private readonly HttpClient Client;

    private static string? jwt;

    public PostService(HttpClient client)
    {
        Client = client;
    }

    public async Task<Post> CreatePost(CreatePostDto dto)
    {
        jwt = JwtAuthService.Jwt;
        Console.WriteLine("HEEEEJ");
        Console.WriteLine(dto);
        Console.WriteLine(jwt);
        HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, "/Post");
        requestMessage.Headers.Add("Authorization", "bearer " + jwt);
        requestMessage.Content = JsonContent.Create(dto);
        
        
        HttpResponseMessage response = await Client.SendAsync(requestMessage);
        string result = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        Post post = JsonSerializer.Deserialize<Post>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        return post;
    }

    public async Task<IEnumerable<Post>> GetPosts()
    {
        string uri = "/post";

        HttpResponseMessage response = await Client.GetAsync(uri);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        IEnumerable<Post> posts = JsonSerializer.Deserialize<IEnumerable<Post>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return posts;
    }

    public async Task<Post> GetPostById(int id)
    {
        string uri = "/post";

        HttpResponseMessage response = await Client.GetAsync(uri + "/" + id);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        Post post = JsonSerializer.Deserialize<Post>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return post;
    }
}