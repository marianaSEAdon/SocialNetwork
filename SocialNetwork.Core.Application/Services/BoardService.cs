using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Core.Application.Base;
using SocialNetwork.Core.Application.Dtos.Board;
using SocialNetwork.Core.Application.Interfaces;
using SocialNetwork.Core.Domain.Entities;
using SocialNetwork.Core.Domain.Interfaces;

namespace SocialNetwork.Core.Application.Services
{
    public class BoardService: GenericService<Board, BoardDto>, IBoardService
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IMapper _mapper;

        public BoardService(IBoardRepository boardRepository, IMapper mapper): base(boardRepository, mapper) 
        {
            _boardRepository = boardRepository;
            _mapper = mapper;
        }


        public async Task<List<BoardDto>> GetAllWithInclude()
        {
            try
            {

                var listEntitiesQuery = _boardRepository.GetAllQueryWithInclude(["Coordinates", "Ships"]);

                if (listEntitiesQuery == null)
                {
                    return [];
                }

                var listEntityDtos = await listEntitiesQuery.ProjectTo<BoardDto>(_mapper.ConfigurationProvider).ToListAsync();

                return listEntityDtos;
            }
            catch
            {
                return [];
            }
        }

    }
}
