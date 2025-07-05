
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Core.Application.Base;
using SocialNetwork.Core.Application.Dtos.Post;
using SocialNetwork.Core.Application.Interfaces;
using SocialNetwork.Core.Domain.Entities;
using SocialNetwork.Core.Domain.Interfaces;

namespace SocialNetwork.Core.Application.Services
{
    public class PostService: GenericService<Post, PostDto>, IPostService
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository, IMapper mapper) : base (postRepository,mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<List<PostDto>> GetAllWithInclude()
        {
            try
            {

                var listEntitiesQuery = _postRepository.GetAllQueryWithInclude(["Comments", "Reactions"]);

                if (listEntitiesQuery == null)
                {
                    return [];
                }
                
                var listEntityDtos = await listEntitiesQuery.ProjectTo<PostDto>(_mapper.ConfigurationProvider).ToListAsync();

                return listEntityDtos;
            }
            catch
            {
                return [];
            }
        }



    }
}
