
namespace SocialNetwork.Core.Domain.Base
{
    public abstract class BaseEntity<Type>
    {
        public abstract Type Id { get; set; }
    }
}
