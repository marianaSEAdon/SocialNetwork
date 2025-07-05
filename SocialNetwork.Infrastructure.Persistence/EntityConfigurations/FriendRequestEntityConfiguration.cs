

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Core.Domain.Entities;

namespace SocialNetwork.Infrastructure.Persistence.EntityConfigurations
{
    public class FriendRequestEntityConfiguration: IEntityTypeConfiguration<FriendRequest>
    {
        public void Configure(EntityTypeBuilder<FriendRequest> builder)
        {
            builder.ToTable("FriendRequests");
            builder.HasKey(x => x.Id);

            #region Property Config
            builder.Property(a => a.RequestingUserId).IsRequired();
            builder.Property(a => a.ReceivingUserId).IsRequired();
            builder.Property(a => a.RequestDate).IsRequired();
            builder.Property(a => a.ResponseDate);
            builder.Property(a => a.Status).IsRequired();
            #endregion
        }
    }
}
