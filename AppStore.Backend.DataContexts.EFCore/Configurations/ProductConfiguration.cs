namespace AppStore.Backend.DataContexts.EFCore.Configurations
{

    internal class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(p => p.IdProduct);

            builder.Property(p => p.InternalCode)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(p => p.InternalCode)
                .IsUnique();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Description)
                .HasMaxLength(500);

            builder.Property(p => p.State)
                .IsRequired();

            builder.Property(p => p.IdCategory).IsRequired();
            builder.Property(p => p.IdSupplier).IsRequired();
            builder.Property(p => p.IdStock).IsRequired();

            // Product → Category (N:1)
            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.IdCategory)
                .OnDelete(DeleteBehavior.Restrict);

            // Product → Supplier (N:1)
            builder.HasOne(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.IdSupplier)
                .OnDelete(DeleteBehavior.Restrict);

            // Product ↔ Stock (1:1)
            builder.HasOne(p => p.Stock)
                .WithOne(s => s.Product)
                .HasForeignKey<ProductEntity>(p => p.IdStock)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(p => p.IdStock).IsUnique();
        }
    }
}
