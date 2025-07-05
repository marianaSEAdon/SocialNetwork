
using AutoMapper;
using SocialNetwork.Core.Application.Base;
using SocialNetwork.Core.Application.Dtos.FriendRequest;
using SocialNetwork.Core.Application.Interfaces;
using SocialNetwork.Core.Domain.Entities;
using SocialNetwork.Core.Domain.Interfaces;

namespace SocialNetwork.Core.Application.Services
{
    public class FriendRequestService: GenericService<FriendRequest, FriendRequestDto>, IFriendRequestService
    {
        private readonly IMapper _mapper;
        private readonly IFriendRequestRepository _friendRequestRepository;
        public FriendRequestService(IFriendRequestRepository friendRequestRepository, IMapper mapper) : base(friendRequestRepository, mapper)
        {
            _friendRequestRepository = friendRequestRepository;
            _mapper = mapper;
        }

        public async Task<FriendRequestDto?> GetBetweenUsersAsync(string userA, string userB)
        {
            var allRequests = await GetAll();
            return allRequests.FirstOrDefault(r =>
                (r.RequestingUserId == userA && r.ReceivingUserId == userB) ||
                (r.RequestingUserId == userB && r.ReceivingUserId == userA));
        }


       
    }
}
