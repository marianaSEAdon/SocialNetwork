
namespace SocialNetwork.Core.Application.Dtos
{
    public abstract class BaseDto<Ttype>
    {
        public abstract Ttype Id { get; set; }
    }
}
