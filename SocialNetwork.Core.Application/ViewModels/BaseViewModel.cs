
namespace SocialNetwork.Core.Application.ViewModels
{
    public abstract class BaseViewModel<Ttype>
    {
        public abstract Ttype Id { get; set; }
    }
}
