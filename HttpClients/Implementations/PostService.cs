﻿using System.Net.Http.Json;
using System.Text.Json;
using Domain;
using Domain.DTOs;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class PostService : IPostService
{
    private readonly HttpClient Client;

    public PostService(HttpClient client)
    {
        Client = client;
    }

    public async Task<Post> CreatePost(CreatePostDto dto)
    {
        Console.WriteLine("HEEEEJ");
        Console.WriteLine(dto);
        HttpResponseMessage response = await Client.PostAsJsonAsync("/Post", dto);
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