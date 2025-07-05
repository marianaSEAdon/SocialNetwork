
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Core.Domain.Entities;

namespace SocialNetwork.Infrastructure.Persistence.EntityConfigurations
{
    public class ReactionEntityConfiguration : IEntityTypeConfiguration<Reaction>
    {
        public void Configure(EntityTypeBuilder<Reaction> builder)
        {
            builder.ToTable("Reactions");
            builder.HasKey(x => x.Id);

            #region Property Config
            builder.Property(c => c.PostId).IsRequired();
            builder.Property(c => c.UserId).IsRequired();
            builder.Property(c => c.ReactionType).IsRequired();
            #endregion

            #region Relationships
            builder.HasOne(i => i.Post)
                .WithMany(ip => ip.Reactions)
                .HasForeignKey(c => c.PostId);
            #endregion


        }
    }
}
