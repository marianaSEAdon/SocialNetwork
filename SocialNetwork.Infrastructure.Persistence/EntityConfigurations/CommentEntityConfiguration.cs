
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Core.Domain.Entities;

namespace SocialNetwork.Infrastructure.Persistence.EntityConfigurations
{
    public class CommentEntityConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(x => x.Id);

            #region Property Config
            builder.Property(a => a.UserId).IsRequired();
            builder.Property(a => a.PostId).IsRequired();
            builder.Property(a => a.CreatedAt).IsRequired();
            builder.Property(a => a.Text).IsRequired();
            builder.Property(a => a.RepliedCommentId);
            #endregion

            #region Relationships
            builder.HasOne(i => i.Post)
                .WithMany(ip => ip.Comments)
                .HasForeignKey(c => c.PostId);

            builder.HasOne(i => i.RepliedComment)
                .WithMany(ip => ip.Replies)
                .HasForeignKey(c => c.RepliedCommentId);
            #endregion
        }
    }
}
