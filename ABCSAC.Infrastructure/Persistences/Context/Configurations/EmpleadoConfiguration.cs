using ABCSAC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ABCSAC.Infrastructure.Persistences.Context.Configurations
{
    public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.HasKey(x => x.Id).HasName("PK__Empleado__CE6D8B9EC89DBEBC"); ;

            builder.Property(e => e.Id)
                .HasColumnName("IdEmpleado");


            
            builder.ToTable("Empleado");

            builder.Property(e => e.Apellidos)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            builder.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            builder.Property(e => e.FechaIngreso).HasColumnType("datetime");
            builder.Property(e => e.FechaNacimiento).HasColumnType("datetime");
            builder.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Sueldo).HasColumnType("decimal(10, 2)");

            builder.HasOne(d => d.Afp).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdAfp)
                .HasConstraintName("FK__Empleado__IdAfp__286302EC");

            builder.HasOne(d => d.Cargo).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdCargo)
                .HasConstraintName("FK__Empleado__IdCarg__29572725");


        }
    }
}
