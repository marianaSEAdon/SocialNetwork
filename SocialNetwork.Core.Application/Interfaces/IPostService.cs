
using SocialNetwork.Core.Application.Dtos.Post;

namespace SocialNetwork.Core.Application.Interfaces
{
    public interface IPostService: IGenericService<PostDto>
    {
        Task<List<PostDto>> GetAllWithInclude();
    }
}
