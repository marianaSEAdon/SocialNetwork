
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Core.Domain.Entities;

namespace SocialNetwork.Infrastructure.Persistence.EntityConfigurations
{
    public class PostEntityConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");
            builder.HasKey(x => x.Id);

            #region Property Config
            builder.Property(c => c.Text).IsRequired();
            builder.Property(c => c.UserId).IsRequired();
            builder.Property(c => c.CreatedAt).IsRequired();
            builder.Property(c => c.Imagen);
            builder.Property(c => c.Video);
            #endregion


        }
    }
}
