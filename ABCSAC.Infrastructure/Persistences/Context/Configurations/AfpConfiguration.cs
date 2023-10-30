using ABCSAC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ABCSAC.Infrastructure.Persistences.Context.Configurations
{
    public class AfpConfiguration : IEntityTypeConfiguration<Afp>
    {
        public void Configure(EntityTypeBuilder<Afp> builder)
        {
            builder.HasKey(x => x.Id).HasName("PK__Cargo__6C985625A913002A"); ;

            builder.Property(e => e.Id)
                .HasColumnName("IdAfp");

            builder.ToTable("Afp");

            builder.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false);
        }
    }
}
