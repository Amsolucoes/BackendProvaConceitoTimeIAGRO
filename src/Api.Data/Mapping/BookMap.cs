using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class BookMap : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            builder.ToTable("Book");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name);

            builder.Property(b => b.Price)
                   .HasMaxLength(10);

            builder.OwnsOne(b => b.Specifications, specifications =>
            {
                specifications.Property(s => s.OriginallyPublished);

                specifications.Property(s => s.Author);

                specifications.Property(s => s.PageCount);

                specifications.Property(s => s.Illustrator);

                specifications.Property(s => s.Genres);
            });

        }
    }
}
