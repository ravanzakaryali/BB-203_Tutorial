using Application.Dtos;

namespace Application.Services.Abstracts;

public interface IPostServcie
{
    Task<PostGetDto> CreateAsync(PostCreateDto post);
}
