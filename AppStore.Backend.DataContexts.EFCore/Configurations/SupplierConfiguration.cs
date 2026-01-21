using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.DataContexts.EFCore.Configurations
{
    internal class SupplierConfiguration : IEntityTypeConfiguration<SupplierEntity>
    {
        public void Configure(EntityTypeBuilder<SupplierEntity> builder)
        {
            builder.HasKey(s => s.IdSupplier);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(s => s.CUIT)
                .IsRequired()
                .HasMaxLength(20);
               

            builder.Property(s => s.Address)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(s => s.PhoneNumber)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(s => s.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(s => s.City)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(s => s.Country)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(s => s.Postcode)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(p => p.State)
                .IsRequired();

            builder.HasIndex(s => s.CUIT).IsUnique();

            builder.HasIndex(s => s.Email).IsUnique();

            // (opcional) relación 1-N con ProductEntity si existe navegación
            builder.HasMany(s => s.Products)
                .WithOne(p => p.Supplier)
                .HasForeignKey(p => p.IdSupplier);
        }
    }
}
