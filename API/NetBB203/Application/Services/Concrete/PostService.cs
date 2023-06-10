using Application.Dtos;
using Application.Services.Abstracts;
using DataAccess.DataContexts;
using DataAccess.Entities;
using DataAccess.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Concrete;

public class PostService : IPostServcie
{
    readonly AppDbContext _dbcontext;

    public PostService(AppDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public async Task<PostGetDto> CreateAsync(PostCreateDto post)
    {
        User? user = await _dbcontext.Users.FirstOrDefaultAsync(u => u.Id == post.UserId)
            ?? throw new NotFoundException("User not found");
        //DbContext interceptor
        Post newPost = new Post()
        {
            UserId = user.Id,
            Description = post.Description,
        };
        await _dbcontext.Posts.AddAsync(newPost);
        await _dbcontext.SaveChangesAsync();
        return new PostGetDto()
        {
            Description = newPost.Description,
            Id = newPost.Id
        };
    }
}
